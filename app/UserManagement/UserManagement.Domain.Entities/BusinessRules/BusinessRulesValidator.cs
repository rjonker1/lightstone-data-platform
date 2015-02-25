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
        public void CheckRules(object enity, string func)
        {
            if (enity is User && func.Equals("Create"))
                 _handler.Handle(new CreateUserRule(enity as User));

            else if (enity is Customer && func.Equals("Create"))
                _handler.Handle(new CreateCustomerRule(enity as Customer));

            else if (enity is Client)
            {
                if (func.Equals("Create")) _handler.Handle(new CreateClientRule(enity as Client));
                if (func.Equals("Delete")) _handler.Handle(new SoftDeleteClientRule(enity as Client));
            }
            else if (enity is Package && func.Equals("Create"))
                _handler.Handle(new CreatePackageRule(enity as Package));

            else if (enity is Contract && func.Equals("Create"))
                _handler.Handle(new CreateContractRule(enity as Contract));
        }
    }
}