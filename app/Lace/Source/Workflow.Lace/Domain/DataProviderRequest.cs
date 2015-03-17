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
}
