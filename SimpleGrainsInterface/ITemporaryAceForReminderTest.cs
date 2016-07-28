using System.Threading.Tasks;
using Orleans;

namespace Rb.Nci.Actor.FacilityGrainsInterface
{
	public interface ITemporaryAceForReminderTest : IGrainWithGuidKey
    {
        Task DoSomethingThatTriggersReminder();

		Task<bool> DidTheReminderFire();

		Task UnregisterReminder();
	}
}
