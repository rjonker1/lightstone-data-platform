using DataPlatform.Shared.Identifiers;

namespace Billing.Api.Dtos
{
    public class CreateTransaction
    {
        public CreateTransaction()
        {
        }

        public CreateTransaction(PackageIdentifier packageIdentifier, TransactionContext context)
        {
            PackageIdentifier = packageIdentifier;
            Context = context;
        }

        public PackageIdentifier PackageIdentifier { get; set; }
        public TransactionContext Context { get; set; }
    }
}