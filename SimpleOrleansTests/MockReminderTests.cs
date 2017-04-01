using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using Orleans.Runtime.Configuration;
using Orleans.TestingHost;
using Rb.Nci.Actor.FacilityGrainsInterface;
using Xunit;
using Xunit.Abstractions;

namespace SimpleOrleansTests
{
	public class MockReminderTests : IClassFixture<MockReminderTests.Fixture>
	{
	    private readonly Fixture _fixture;
		private readonly ITestOutputHelper output;

	    public class Fixture : BaseTestClusterFixture
	    {
	        protected override TestCluster CreateTestCluster()
	        {
	            TestClusterOptions options = new TestClusterOptions();

	            options.ClusterConfiguration.AddMemoryStorageProvider("PubSubStore");
	            options.ClusterConfiguration.Globals.ClientDropTimeout = TimeSpan.FromSeconds(5);
	            options.ClusterConfiguration.ApplyToAllNodes(o => o.DefaultTraceLevel = Orleans.Runtime.Severity.Verbose2);

                //this works
                //options.ClusterConfiguration.Globals.ReminderServiceType =
                //    GlobalConfiguration.ReminderServiceProviderType.ReminderTableGrain;

                //causes failure when reminder is created
                //options.ClusterConfiguration.Globals.ReminderServiceType =
                //    GlobalConfiguration.ReminderServiceProviderType.Disabled;

                //causes failure when reminder is created
                //options.ClusterConfiguration.Globals.ReminderServiceType =
                //    GlobalConfiguration.ReminderServiceProviderType.NotSpecified;


                options.ClusterConfiguration.Globals.ReminderServiceType = GlobalConfiguration.ReminderServiceProviderType.Custom;
	            options.ClusterConfiguration.Globals.ReminderTableAssembly = "SimpleOrleansTests";

                return new TestCluster(options);
	        }

	    }

		public MockReminderTests(MockReminderTests.Fixture fixture, ITestOutputHelper output)
		{
			this.output = output;
		    this._fixture = fixture;

		}

	    [Theory]
	    [InlineData("B497607F-9641-4E05-893D-35CDC923BCB7")]
	    [InlineData("2FB638B0-61AC-4C45-8F4A-0A833E112044")]
	    [InlineData("16741490-4BB5-4613-ACA0-ECD7B31A981B")]
	    [InlineData("14D2D56A-B13B-4718-B6BA-BDE3772ED3A9")]
	    [InlineData("D356DFC9-5B96-4963-B58D-9228D6BC44F0")]
	    [InlineData("A4F5FBAA-86F3-44F2-8539-6E170E5644EE")]
	    public async Task SubscribeAndPublishSomeAces(string id)
	    {
	        try
	        {
	            //Guid streamId = Guid.NewGuid();
	            Guid streamId = Guid.Parse(id);

	            //get ace grain
	            var myAce = _fixture.HostedCluster.GrainFactory.GetGrain<ITemporaryAceForReminderTest>(streamId);

	            //give it a value (triggers the reminder)
	            await myAce.DoSomethingThatTriggersReminder();

	            //wait until reminder should have fired
	            await Task.Delay(1250); //NOTE: 61000 milliseconds is 1:01... reminder should have triggered by now

	            //check if reminder fired
	            bool reminderDidFire = await myAce.DidTheReminderFire();

	            //clean up
	            await myAce.UnregisterReminder();

	            //test
	            Assert.True(reminderDidFire);
	        }
	        catch (Exception ex)
	        {
	            this.output.WriteLine(ex.ToString());
	            throw;
	        }
	    }
	}
}
