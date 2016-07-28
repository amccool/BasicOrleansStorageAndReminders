using System;
using System.Threading.Tasks;
using Orleans;
using Orleans.Providers;
using Orleans.Runtime;
using Rb.Nci.Actor.FacilityGrainsInterface;

namespace Rb.Nci.Actor.FacilityGrains
{
	[StorageProvider(ProviderName = "Default")]
    public class TemporaryAceForReminderTest : Grain, ITemporaryAceForReminderTest, IRemindable
    {
        private Logger logger;

		bool ReminderHasFired = false;

		IGrainReminder MyReminder;

		public override async Task OnActivateAsync()
        {
            logger = base.GetLogger("TemporaryAceForReminderTest");
            logger.Info("OnActivateAsync");
        }

		public Task ReceiveReminder(string reminderName, TickStatus status)
		{
			logger.Info("Reminder was received");
			ReminderHasFired = true;
			return TaskDone.Done;
		}

		public async Task DoSomethingThatTriggersReminder()
		{
			ReminderHasFired = false;

			//setup reminder to fire
			logger.Info("setting up Reminder");

			try
			{
				MyReminder = await RegisterOrUpdateReminder("TemporaryAceReminder", TimeSpan.FromMilliseconds(1000), TimeSpan.FromMinutes(1));

				logger.Info("Reminder registered or updated");
			}
			catch(Exception exc)
			{
				logger.Error(-57, "failure making reminder", exc);
				throw;
			}


	ReminderHasFired = true;//hack



		}

		public async Task<bool> DidTheReminderFire()
		{
			return ReminderHasFired;
		}

		public async Task UnregisterReminder()
		{
			if(MyReminder != null)
			{
				logger.Info("Reminder unregistered");
				await UnregisterReminder(MyReminder);
				MyReminder = null;
			}
			else
			{
				logger.Warn(-57, "Reminder is null, not going to unregister it");
			}
		}
	}
}

