using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.BusinessRules.Lookups.CreateSources
{
    public class DeleteCreateSourceRule : DomainCommand
    {

        public CreateSource Entity;

        public DeleteCreateSourceRule(CreateSource entity)
        {
            Entity = entity;
        }
    }
}