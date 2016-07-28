using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Orleans.Runtime.Configuration;
using Orleans.TestingHost;
using Rb.Nci.Actor.FacilityGrainsInterface;
using Xunit;
using Xunit.Abstractions;

namespace SimpleOrleansTests
{
	public class ReminderTest
	{
#region Constructor and setup
		private static TestCluster testingCluster;
		private readonly ITestOutputHelper output;

		public ReminderTest(ITestOutputHelper output)
		{
			this.output = output;

			testingCluster = CreateTestCluster();
			testingCluster.Deploy();
		}

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose(bool disposing)
		{
			if(!disposedValue)
			{
				if(disposing)
				{
					// TODO: dispose managed state (managed objects).
					// Optional. 
					// By default, the next test class which uses TestignSiloHost will
					// cause a fresh Orleans silo environment to be created.
					testingCluster.StopAllSilos();

				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		// ~FacilityGrainTest() {
		//   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
		//   Dispose(false);
		// }

		// This code added to correctly implement the disposable pattern.
		public void Dispose()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose(true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			// GC.SuppressFinalize(this);
		}
		#endregion

		public static TestCluster CreateTestCluster()
		{
			TestClusterOptions options = new TestClusterOptions();

			options.ClusterConfiguration.AddMemoryStorageProvider("PubSubStore");
			options.ClusterConfiguration.Globals.ClientDropTimeout = TimeSpan.FromSeconds(5);
			options.ClusterConfiguration.Defaults.DefaultTraceLevel = Orleans.Runtime.Severity.Warning;
			options.ClusterConfiguration.Globals.ReminderServiceType = GlobalConfiguration.ReminderServiceProviderType.ReminderTableGrain;

			return new TestCluster(options);
		}
#endregion Constructor and setup

		[Fact]
		public async Task SubscribeAndPublishSomeAces()
		{
			try
			{
				Guid streamId = Guid.NewGuid();

				//get ace grain
				var myAce = testingCluster.GrainFactory.GetGrain<ITemporaryAceForReminderTest>(streamId);

				//give it a value (triggers the reminder)
				await myAce.DoSomethingThatTriggersReminder();

				//wait until reminder should have fired
				await Task.Delay(1001);	//NOTE: 61000 milliseconds is 1:01... reminder should have triggered by now

				//check if reminder fired
				bool reminderDidFire = await myAce.DidTheReminderFire();

				//clean up
				await myAce.UnregisterReminder();

				//test
				Assert.True(reminderDidFire);
			}
			catch(Exception exc)
			{
				Debugger.Break();   //FYI dev!
				throw;
			}
		}
	}
}
