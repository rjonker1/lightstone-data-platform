using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities.BusinessRules.Clients;
using UserManagement.Domain.Entities.BusinessRules.Contracts;
using UserManagement.Domain.Entities.BusinessRules.Customers;
using UserManagement.Domain.Entities.BusinessRules.Packages;
using UserManagement.Domain.Entities.BusinessRules.Users;

namespace UserManagement.Domain.Entities.BusinessRules
{
    public class BusinessRulesValidator
    {
        private readonly IHandleMessages _handler;

        public BusinessRulesValidator(IHandleMessages handler)
        {
            _handler = handler;
        }

        //Run rules based on entity type of the currently transacted entity.
        public void CheckRules(object enity)
        {
            if (enity is User)
                _handler.Handle(new CreateUserRule(enity as User));
            else if (enity is Customer)
                _handler.Handle(new CreateCustomerRule(enity as Customer));
            else if (enity is Client)
                _handler.Handle(new CreateClientRule(enity as Client));
            else if (enity is Package)
                _handler.Handle(new CreatePackageRule(enity as Package));
            else if (enity is Contract)
                _handler.Handle(new CreateContractRule(enity as Contract));
        }
    }
}