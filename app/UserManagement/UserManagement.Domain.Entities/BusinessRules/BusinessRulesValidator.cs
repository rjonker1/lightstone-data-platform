using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities.BusinessRules.Clients;
using UserManagement.Domain.Entities.BusinessRules.Contracts;
using UserManagement.Domain.Entities.BusinessRules.Customers;
using UserManagement.Domain.Entities.BusinessRules.Lookups.CommercialStates;
using UserManagement.Domain.Entities.BusinessRules.Lookups.ContractDurations;
using UserManagement.Domain.Entities.BusinessRules.Lookups.ContractTypes;
using UserManagement.Domain.Entities.BusinessRules.Lookups.EscalationTypes;
using UserManagement.Domain.Entities.BusinessRules.Lookups.PaymentTypes;
using UserManagement.Domain.Entities.BusinessRules.Lookups.Provinces;
using UserManagement.Domain.Entities.BusinessRules.Lookups.Roles;
using UserManagement.Domain.Entities.BusinessRules.Packages;
using UserManagement.Domain.Entities.BusinessRules.Roles;
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
                if (func.Equals("Create") || func.Equals("Update")) _handler.Handle(new CreateUserRule(entity as User));
                if (func.Equals("Delete")) _handler.Handle(new SoftDeleteUserRule(entity as User));
            }
            else if (entity is Customer)
            {
                if (func.Equals("Create")) _handler.Handle(new CreateCustomerRule(entity as Customer));
                if (func.Equals("Update")) _handler.Handle(new UpdateCustomerRule(entity as Customer));
                if (func.Equals("Delete")) _handler.Handle(new SoftDeleteCustomerRule(entity as Customer));
            }
            else if (entity is Client)
            {
                if (func.Equals("Create")) _handler.Handle(new CreateClientRule(entity as Client));
                if (func.Equals("Update")) _handler.Handle(new UpdateClientRule(entity as Client));
                if (func.Equals("Delete")) _handler.Handle(new SoftDeleteClientRule(entity as Client));
            }
            else if (entity is Package && (func.Equals("Create") || func.Equals("Update")))
                _handler.Handle(new CreatePackageRule(entity as Package));
            else if (entity is Role && (func.Equals("Create") || func.Equals("Update")))
                _handler.Handle(new CreateRoleRule(entity as Role));
            else if (entity is Contract)
            {
                if (func.Equals("Create") || func.Equals("Update")) _handler.Handle(new CreateContractRule(entity as Contract));
                if(func.Equals("Delete")) _handler.Handle(new SoftDeleteContractRule(entity as Contract));
            }

            //Hard delete entities
            if (entity is PaymentType) _handler.Handle(new DeletePaymentTypeRule(entity as PaymentType));
            if (entity is CommercialState) _handler.Handle(new DeleteCommercialStateRule(entity as CommercialState));
            if (entity is ContractType) _handler.Handle(new DeleteContractTypeRule(entity as ContractType));
            if (entity is EscalationType) _handler.Handle(new DeleteEscalationTypeRule(entity as EscalationType));
            if (entity is ContractDuration) _handler.Handle(new DeleteContractDurationRule(entity as ContractDuration));
            if (entity is Province) _handler.Handle(new DeleteProvinceRule(entity as Province));
            if (entity is Role) _handler.Handle(new DeleteRoleRule(entity as Role));
        }
    }
}