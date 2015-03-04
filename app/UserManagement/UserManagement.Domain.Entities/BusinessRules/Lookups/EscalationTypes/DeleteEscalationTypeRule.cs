using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.BusinessRules.Lookups.EscalationTypes
{
    public class DeleteEscalationTypeRule : DomainCommand
    {

        public EscalationType Entity;

        public DeleteEscalationTypeRule(EscalationType entity)
        {
            Entity = entity;
        }
    }
}