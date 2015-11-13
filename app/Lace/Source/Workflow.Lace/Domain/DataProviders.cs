using Workflow.Lace.Identifiers;

namespace Workflow.Lace.Domain
{
    public class DataProviderTransaction
    {
        public DataProviderTransaction(DataProviderTransactionIdentifier transaction)
        {
            Transaction = transaction;
        }

        public DataProviderTransactionIdentifier Transaction { get; private set; }
    }

    public class DataProviderEvent
    {
        public DataProviderEvent(EventIndentifier command)
        {
            Command = command;
        }
        public EventIndentifier Command { get; private set; }
    }
}
