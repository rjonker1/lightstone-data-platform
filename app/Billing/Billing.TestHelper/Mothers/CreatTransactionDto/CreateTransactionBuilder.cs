using Billing.Api.Dtos;
using DataPlatform.Shared.Identifiers;

namespace Billing.TestHelper.Mothers.CreatTransactionDto
{
    public class CreateTransactionBuilder
    {
        private TransactionContext context;
        private PackageIdentifier package;
        private ContractIdentifier contract;
        private AccountIdentifier account;

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
        
        public CreateTransactionBuilder WithContractIdentifier(ContractIdentifier contract)
        {
            this.contract = contract;
            return this;
        }
        
        public CreateTransactionBuilder WithAccountIdentifier(AccountIdentifier account)
        {
            this.account = account;
            return this;
        }

        public CreateTransaction Build()
        {
            return new CreateTransaction(package, context, contract, account);
        }

        public CreateTransaction Build(IDefineCreateTransactionData data)
        {
            return WithTransactionContext(data.Context)
                .WithPackageIdentifier(data.Package)
                .WithContractIdentifier(data.Contract)
                .WithAccountIdentifier(data.Account)
                .Build();
        }
    }
}