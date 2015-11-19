using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.Entities
{
    public class SoftDeleteEntity : DomainCommand
    {
        public Entity Entity;

        public SoftDeleteEntity(Entity entity)
        {
            Entity = entity;
        }
    }
}