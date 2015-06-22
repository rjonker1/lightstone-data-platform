using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.BusinessRules.Lookups.ContractDurations
{
    public class DeleteContractDurationRule : DomainCommand
    {
        public Country Entity;

        public DeleteContractDurationRule(Country entity)
        {
            Entity = entity;
        }
    }
}