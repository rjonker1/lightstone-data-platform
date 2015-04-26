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

    public class DataProviderCommand
    {
        public DataProviderCommand(CommandIndentifier command)
        {
            Command = command;
        }
        public CommandIndentifier Command { get; private set; }
    }
}
