using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.BusinessRules.Contracts
{
    public class SoftDeleteContractRule : DomainCommand
    {
        public Contract Entity;

        public SoftDeleteContractRule(Contract entity)
        {
            Entity = entity;
        }
    }
}