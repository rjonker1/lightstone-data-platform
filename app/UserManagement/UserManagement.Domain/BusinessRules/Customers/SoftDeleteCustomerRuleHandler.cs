using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.BusinessRules.Customers;

namespace UserManagement.Domain.BusinessRules.Customers
{
    public class SoftDeleteCustomerRuleHandler : AbstractMessageHandler<SoftDeleteCustomerRule>
    {

        private readonly IRepository<Customer> _customers;

        public SoftDeleteCustomerRuleHandler(IRepository<Customer> customers)
        {
            _customers = customers;
        }

        public override void Handle(SoftDeleteCustomerRule command)
        {

            var entity = command.Entity;
            var hasCustomerUser = _customers.Where(x => x.Users.Any());

            if (hasCustomerUser.Any())
            {
                var exception = new LightstoneAutoException("Customer cannot be deleted due to Customer - User relationship".FormatWith(entity.GetType().Name));
                this.Warn(() => exception);
                throw exception;
            }

            entity.IsDeleted = true;
        }
    }
}