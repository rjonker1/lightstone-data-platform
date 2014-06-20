using Billing.Api.Dtos;
using DataPlatform.Shared.Identifiers;

namespace Billing.TestHelper.Mothers.CreatTransactionDto
{
    public class CreateTransactionBuilder
    {
        private TransactionContext context;
        private PackageIdentifier package;

        public CreateTransactionBuilder WithPackageIdentifier(PackageIdentifier package)
        {
            this.package = package;
            return this;
        }

        public CreateTransactionBuilder WithTransactionContext(TransactionContext context)
        {
            this.context = context;
            return this;
        }

        public CreateTransaction Build()
        {
            return new CreateTransaction(package, context);
        }

        public CreateTransaction Build(IDefineCreateTransactionData data)
        {
            return WithTransactionContext(data.Context)
                .WithPackageIdentifier(data.Package)
                .Build();
        }
    }
}