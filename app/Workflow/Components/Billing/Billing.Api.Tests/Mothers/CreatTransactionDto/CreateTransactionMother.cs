using Billing.Api.Dtos;

namespace Billing.Api.Tests.Mothers.CreatTransactionDto
{
    public class CreateTransactionMother
    {
        public CreateTransaction DefaultCreateTransaction()
        {
            return new CreateTransactionBuilder()
                .Build(new DefaultCreateTransactionData());
        }
    }
}
