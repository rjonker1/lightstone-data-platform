using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities.BusinessRules.Clients;
using UserManagement.Domain.Entities.BusinessRules.Contracts;
using UserManagement.Domain.Entities.BusinessRules.Customers;
using UserManagement.Domain.Entities.BusinessRules.Lookups.CommercialStates;
using UserManagement.Domain.Entities.BusinessRules.Lookups.ContractDurations;
using UserManagement.Domain.Entities.BusinessRules.Lookups.ContractTypes;
using UserManagement.Domain.Entities.BusinessRules.Lookups.Provinces;
using UserManagement.Domain.Entities.BusinessRules.Lookups.Roles;
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
        public void CheckRules(object entity, string func)
        {
            //Soft delete entities
            if (entity is User)
            {
                if (func.Equals("Delete")) _handler.Handle(new SoftDeleteUserRule(entity as User));
            }
            else if (entity is Customer)
            {
                if (func.Equals("Delete")) _handler.Handle(new SoftDeleteCustomerRule(entity as Customer));
            }
            else if (entity is Client)
            {
                if (func.Equals("Delete")) _handler.Handle(new SoftDeleteClientRule(entity as Client));
            }
            else if (entity is Contract)
            {
                if(func.Equals("Delete")) _handler.Handle(new SoftDeleteContractRule(entity as Contract));
            }

            //Hard delete entities
            if (entity is CommercialState) _handler.Handle(new DeleteCommercialStateRule(entity as CommercialState));
            if (entity is ContractType) _handler.Handle(new DeleteContractTypeRule(entity as ContractType));
            if (entity is Country) _handler.Handle(new DeleteContractDurationRule(entity as Country));
            if (entity is Province) _handler.Handle(new DeleteProvinceRule(entity as Province));
            if (entity is Role) _handler.Handle(new DeleteRoleRule(entity as Role));
        }
    }
}