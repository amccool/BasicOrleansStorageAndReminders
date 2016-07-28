using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using SimpleGrainsInterface;
using Orleans.Runtime.Configuration;
using Orleans.TestingHost;
using SimpleSQLServerStorage.Tests;
using Xunit;
using Xunit.Abstractions;

namespace SimpleOrleansTests
{
	/// <summary>
	/// Use a grain with state; an integer in this case
	/// 1) Deploy a cluster
	///		a) set the grain's state
	/// 2) Stop the cluster
	/// 3) Deploy another cluster 
	///		a) read the grain's state
	///		b) confirm the state was saved from before
	///		
	/// Based on the code from Alex's https://github.com/OrleansContrib/Orleans.StorageProviders.SimpleSQLServerStorage
	/// </summary>
	public class SqlStorageStateTest
	{
		private readonly ITestOutputHelper output;

		public SqlStorageStateTest(ITestOutputHelper output)
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

			options.ClusterConfiguration.AddSimpleSQLStorageProvider("basic",
				string.Format(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename={0};Trusted_Connection=Yes", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "basic.mdf")),
				"true");

			return new TestCluster(options);
		}

		[Fact]
		public async Task StateSavingTest()
		{
			try
			{
				TestCluster testingCluster = CreateTestCluster();

				Guid testGuid = Guid.NewGuid();

				#region Cluster Run #1
				testingCluster.Deploy();


				ISimpleStateTestGrain testGrain1 = testingCluster.GrainFactory.GetGrain<ISimpleStateTestGrain>(testGuid);
				Random random = new Random();
				int myTestNumber = random.Next(1, 999999);
				await testGrain1.SetTheNumber(myTestNumber);
				int myNumberCheck1 = await testGrain1.GetTheNumber();
				Assert.Equal(myNumberCheck1, myTestNumber);


				testingCluster.StopAllSilos();
				#endregion Cluster Run #1


				//restart a new cluster, just like the one before


				#region Cluster Run #2
				testingCluster.Deploy();


				ISimpleStateTestGrain testGrain2 = testingCluster.GrainFactory.GetGrain<ISimpleStateTestGrain>(testGuid);
				int myNumberCheck2 = await testGrain2.GetTheNumber();
				Assert.Equal(myNumberCheck2, myTestNumber);	//the SQL storage provider DID restore our number
				

				testingCluster.StopAllSilos();
				#endregion Cluster Run #2
			}
			catch(Exception exc)
			{
				Debugger.Break();   //FYI dev!
				throw;
			}
		}
	}
}
