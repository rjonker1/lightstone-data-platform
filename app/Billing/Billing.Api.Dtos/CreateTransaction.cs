using DataPlatform.Shared.Identifiers;

namespace Billing.Api.Dtos
{
    public class CreateTransaction
    {
        public CreateTransaction()
        {
        }

        public CreateTransaction(PackageIdentifier packageIdentifier, TransactionContext context, ContractIdentifier contract)
        {
            PackageIdentifier = packageIdentifier;
            Context = context;
            Contract = contract;
        }

        public PackageIdentifier PackageIdentifier { get; set; }
        public TransactionContext Context { get; set; }
        public ContractIdentifier Contract { get; set; }
    }
}