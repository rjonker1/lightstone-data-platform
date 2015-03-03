using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities.BusinessRules.Lookups.PaymentTypes;

namespace UserManagement.Domain.BusinessRules.Lookups.PaymentTypes
{
    public class DeletePaymentTypeRuleHandler : AbstractMessageHandler<DeletePaymentTypeRule>
    {
        public override void Handle(DeletePaymentTypeRule command)
        {
            throw new System.NotImplementedException();
        }
    }
}