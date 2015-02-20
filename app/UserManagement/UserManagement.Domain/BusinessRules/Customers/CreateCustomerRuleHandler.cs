using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.BusinessRules.Customers;

namespace UserManagement.Domain.BusinessRules.Customers
{
    public class CreateCustomerRuleHandler : AbstractMessageHandler<CreateCustomerRule>
    {
        private readonly INamedEntityRepository<Customer> _currentCustomers;

        public CreateCustomerRuleHandler(INamedEntityRepository<Customer> currentCustomers)
        {
            _currentCustomers = currentCustomers;
        }

        public override void Handle(CreateCustomerRule command)
        {
            var entity = command.Entity;

            //Check if Username for specific user already exists
            if (_currentCustomers.Exists(entity.Id, entity.Name))
            {
                var exception = new LightstoneAutoException("Customer already exists".FormatWith(entity.GetType().Name));
                this.Warn(() => exception);
                throw exception;
            }
        }
    }
}