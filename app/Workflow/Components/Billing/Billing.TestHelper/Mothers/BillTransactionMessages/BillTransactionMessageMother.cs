using Workflow.Billing.Messages;

namespace Billing.TestHelper.Mothers.BillTransactionMessages
{
    public class BillTransactionMessageMother
    {
        public static BillTransactionMessage BillTransactionMessage()
        {
            return new BillTransactionMessageBuilder().With(new BillingTransaction()).Build();
        }
    }
}