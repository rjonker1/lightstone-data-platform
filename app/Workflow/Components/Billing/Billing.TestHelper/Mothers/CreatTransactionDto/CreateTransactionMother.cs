using Billing.Api.Dtos;

namespace Billing.TestHelper.Mothers.CreatTransactionDto
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
