using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orleans;
using Orleans.Runtime;
using Orleans.Runtime.Configuration;

namespace SimpleOrleansTests
{
    public class ReminderTableMocked : IReminderTable
    {
        private Logger _logger;

        public Task Init(GlobalConfiguration config, Logger logger)
        {
            this._logger = logger;

            this._logger.Error(99999, "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");

            return TaskDone.Done;
        }

        public async Task<ReminderTableData> ReadRows(GrainReference key)
        {
            this._logger.Error(99999, "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
            return new ReminderTableData();
        }

        public async Task<ReminderTableData> ReadRows(uint begin, uint end)
        {
            this._logger.Error(99999, "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
            return new ReminderTableData();
        }

        public async Task<ReminderEntry> ReadRow(GrainReference grainRef, string reminderName)
        {
            this._logger.Error(99999, "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
            return new ReminderEntry();
        }

        public async Task<string> UpsertRow(ReminderEntry entry)
        {
            this._logger.Error(99999, "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
            return string.Empty;
        }

        public async Task<bool> RemoveRow(GrainReference grainRef, string reminderName, string eTag)
        {
            this._logger.Error(99999, "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
            return true;
        }

        public Task TestOnlyClearTable()
        {
            this._logger.Error(99999, "hhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh");
            return TaskDone.Done;
        }
    }
}
