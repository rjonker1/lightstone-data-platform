using System;

namespace Lim.Schedule.Core.Commands
{
    public class TrackIntegrationCommand
    {
        public readonly DateTime MaxTransactionDate;
        public readonly long ConfigurationId;
        public readonly long TransactionsCount;

        public TrackIntegrationCommand(DateTime maxTransactionDate, long configurationId, long transactionCount)
        {
            MaxTransactionDate = maxTransactionDate;
            ConfigurationId = configurationId;
            TransactionsCount = transactionCount;
        }
    }

    public class GetLastTransactionDateCommand
    {
        public readonly long ConfigurationId;

        public GetLastTransactionDateCommand(long configurationId)
        {
            ConfigurationId = configurationId;
        }

        public void Set(DateTime trackDate)
        {
            TransactionTrackDate = trackDate;
        }

        public DateTime? TransactionTrackDate { get; private set; }
    }
}
