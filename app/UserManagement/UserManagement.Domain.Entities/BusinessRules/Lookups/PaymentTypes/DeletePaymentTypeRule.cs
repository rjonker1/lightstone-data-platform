using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.BusinessRules.Lookups.PaymentTypes
{
    public class DeletePaymentTypeRule : DomainCommand
    {
        public PaymentType Entity;

        public DeletePaymentTypeRule(PaymentType entity)
        {
            Entity = entity;
        }
    }
}