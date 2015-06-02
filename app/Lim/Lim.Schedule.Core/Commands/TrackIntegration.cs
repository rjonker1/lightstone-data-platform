using System;

namespace Lim.Schedule.Core.Commands
{
    public class TrackIntegrationCommand
    {
        public readonly DateTime MaxTransactionDate;
        public readonly short Action;
        public readonly short Type;
        public readonly short Frequency;
        public readonly long TransactionsIntegrated;

        public TrackIntegrationCommand(DateTime maxTransactionDate, short action, short type, short frequency, long recordsIntegrated)
        {
            MaxTransactionDate = maxTransactionDate;
            Action = action;
            Type = type;
            Frequency = frequency;
            TransactionsIntegrated = recordsIntegrated;
        }
    }

    public class GetLastTransactionDateCommand
    {
        public readonly short Action;
        public readonly short Type;
        public readonly short Frequency;

        public GetLastTransactionDateCommand(short action, short type, short frequency)
        {
            Action = action;
            Type = type;
            Frequency = frequency;
        }

        public void Set(DateTime trackDate)
        {
            TransactionTrackDate = trackDate;
        }

        public DateTime? TransactionTrackDate { get; private set; }
    }
}
