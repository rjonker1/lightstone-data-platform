using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.BusinessRules.Lookups.ContractDurations
{
    public class DeleteContractDurationRule : DomainCommand
    {
        public ContractDuration Entity;

        public DeleteContractDurationRule(ContractDuration entity)
        {
            Entity = entity;
        }
    }
}