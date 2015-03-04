using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.BusinessRules.Lookups.ContractTypes
{
    public class DeleteContractTypeRule : DomainCommand
    {

        public ContractType Entity;

        public DeleteContractTypeRule(ContractType entity)
        {
            Entity = entity;
        }
    }
}