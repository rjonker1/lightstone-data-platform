using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.BusinessRules.Customers;

namespace UserManagement.Domain.CommandHandlers.BusinessRules.Customers
{
    public class CreateCustomerRuleHandler : AbstractMessageHandler<CreateCustomerRule>
    {

        private readonly IRepository<Customer> _currentCustomers;

        public CreateCustomerRuleHandler(IRepository<Customer> currentCustomers)
        {
            _currentCustomers = currentCustomers;
        }

        public override void Handle(CreateCustomerRule command)
        {
            var entity = command.Entity;

            //Check if Username for specific user already exists
            if (Enumerable.Any(_currentCustomers, client => client.Name.Equals(entity.Name)))
            {
                var exception = new LightstoneAutoException("Customer already exists".FormatWith(entity.GetType().Name));
                this.Warn(() => exception);
                throw exception;
            }
        }
    }
}