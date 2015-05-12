using System.Linq;
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

            //Check if Customer already exists
            if (_currentCustomers.Any(x => x.Name == command.Entity.Name))
            {
                var exception = new LightstoneAutoException("Customer already exists".FormatWith(entity.GetType().Name));
                this.Warn(() => exception);
                throw exception;
            }

            //Customer Account Number
            if (_currentCustomers.Any(x => x.CustomerAccountNumber == command.Entity.CustomerAccountNumber))
            {
                var exception = new LightstoneAutoException("Customer AccountNumber is already assigned".FormatWith(entity.GetType().Name));
                this.Warn(() => exception);
                throw exception;
            }

            //Company Registration
            if (_currentCustomers.Any(x => x.Billing.CompanyRegistration == command.Entity.Billing.CompanyRegistration))
            {
                var exception = new LightstoneAutoException("Company register number is already assigned".FormatWith(entity.GetType().Name));
                this.Warn(() => exception);
                throw exception;
            }

            if (_currentCustomers.Any(x => x.Billing.VatNumber == command.Entity.Billing.VatNumber))
            {
                var exception = new LightstoneAutoException("Company vat number is already assigned".FormatWith(entity.GetType().Name));
                this.Warn(() => exception);
                throw exception;
            }
        }
    }
}