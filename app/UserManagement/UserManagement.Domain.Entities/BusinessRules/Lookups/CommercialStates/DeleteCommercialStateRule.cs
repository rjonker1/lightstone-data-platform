using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.BusinessRules.Lookups.CommercialStates
{
    public class DeleteCommercialStateRule : DomainCommand
    {

        public CommercialState Entity;

        public DeleteCommercialStateRule(CommercialState entity)
        {
            Entity = entity;
        }
    }
}