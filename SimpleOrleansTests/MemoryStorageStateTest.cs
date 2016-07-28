using System;
using System.Diagnostics;
using System.Threading.Tasks;
using SimpleGrainsInterface;
using Orleans.Runtime.Configuration;
using Orleans.TestingHost;
using Xunit;
using Xunit.Abstractions;

namespace SimpleOrleansTests
{
	public class MemoryStorageStateTest
	{
		private readonly ITestOutputHelper output;

		public MemoryStorageStateTest(ITestOutputHelper output)
		{
			this.output = output;
		}

		#region IDisposable Support
		public void Dispose()
		{
		}
		#endregion

		public static TestCluster CreateTestCluster()
		{
			TestClusterOptions options = new TestClusterOptions();

			options.ClusterConfiguration.AddMemoryStorageProvider("basic");

			return new TestCluster(options);
		}

		[Fact]
		public async Task StateWithNoSqlStorage()
		{
			try
			{
				TestCluster testingCluster = CreateTestCluster();

				Guid testGuid = Guid.NewGuid();

				#region Cluster #1
				testingCluster.Deploy();

				ISimpleStateTestGrain testGrain1 = testingCluster.GrainFactory.GetGrain<ISimpleStateTestGrain>(testGuid);
				Random random = new Random();
				int myTestNumber = random.Next(1, 999999);
				await testGrain1.SetTheNumber(myTestNumber);
				int myNumberCheck1 = await testGrain1.GetTheNumber();
				Assert.Equal(myNumberCheck1, myTestNumber);

				testingCluster.StopAllSilos();
				#endregion Cluster #1




				#region Cluster #2
				testingCluster.Deploy();


				ISimpleStateTestGrain testGrain2 = testingCluster.GrainFactory.GetGrain<ISimpleStateTestGrain>(testGuid);
				int myNumberCheck2 = await testGrain2.GetTheNumber();
				Assert.Equal(myNumberCheck2, 0);	//the memory storage provider did NOT restore our number

				testingCluster.StopAllSilos();
				#endregion Cluster #2
			}
			catch(Exception exc)
			{
				Debugger.Break();   //FYI dev!
				throw;
			}
		}
	}
}
