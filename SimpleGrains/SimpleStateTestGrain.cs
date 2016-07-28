using System;
using System.Threading.Tasks;
using SimpleGrainsInterface;
using Orleans;
using Orleans.Providers;

namespace SimpleGrains
{
	[StorageProvider(ProviderName="basic")]
	public class SimpleStateTestGrain : Grain<SimpleStateTestGrainState>, ISimpleStateTestGrain
	{

#region ISimpleTestGrainState
		public Task SetTheNumber(int theNumber)
		{
			State.MyNumber = theNumber;
			return base.WriteStateAsync();
		}

		public async Task<int> GetTheNumber()
		{
			//await base.ReadStateAsync();
			return State.MyNumber;
		}
#endregion ISimpleTestGrainState
	}
}
