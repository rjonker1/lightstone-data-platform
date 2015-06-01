using System;
using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.BusinessRules.Customers;

namespace UserManagement.Domain.BusinessRules.Customers
{
    public class UpdateCustomerRuleHandler : AbstractMessageHandler<UpdateCustomerRule>
    {
        private readonly INamedEntityRepository<Customer> _currentCustomers;

        public UpdateCustomerRuleHandler(INamedEntityRepository<Customer> currentCustomers)
        {
            _currentCustomers = currentCustomers;
        }

        public override void Handle(UpdateCustomerRule command)
        {
            var entity = command.Entity;

            try
            {
                _currentCustomers.Exists(entity.Id, entity.Name);
            }
            catch (Exception e)
            {
                var exception = new LightstoneAutoException("Customer name already exists".FormatWith(entity.GetType().Name));
                this.Warn(() => exception);
                throw exception;
            }
            
            
            //if (_currentCustomers.Exists(entity.Id, entity.Name))
            //{
            //    var exception = new LightstoneAutoException("Customer name already exists".FormatWith(entity.GetType().Name));
            //    this.Warn(() => exception);
            //    throw exception;
            //}
        }
    }
}