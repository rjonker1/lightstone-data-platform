using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.BusinessRules.Lookups.PaymentTypes;

namespace UserManagement.Domain.BusinessRules.Lookups.PaymentTypes
{
    public class DeletePaymentTypeRuleHandler : AbstractMessageHandler<DeletePaymentTypeRule>
    {

        private readonly IRepository<Billing> _billingListings;

        public DeletePaymentTypeRuleHandler(IRepository<Billing> billingListings)
        {
            _billingListings = billingListings;
        }

        public override void Handle(DeletePaymentTypeRule command)
        {
            var entity = command.Entity;
            var paymentTypes = _billingListings.Select(x => x).Where(x => x.PaymentType != null);

            if (paymentTypes.Any())
            {
                var exception = new LightstoneAutoException("PaymentType is associated therefore cannot be deleted".FormatWith(entity.GetType().Name));
                this.Warn(() => exception);
                throw exception;
            }
        }
    }
}