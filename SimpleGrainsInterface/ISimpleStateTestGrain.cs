using System.Threading.Tasks;
using Orleans;

namespace SimpleGrainsInterface
{
	public interface ISimpleStateTestGrain : IGrainWithGuidKey
	{
		Task SetTheNumber(int theNumber);

		Task<int> GetTheNumber();
	}
}
