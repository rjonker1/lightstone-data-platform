using UserManagement.Domain.Core.Commands;
using UserManagement.Domain.Core.Entities;

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