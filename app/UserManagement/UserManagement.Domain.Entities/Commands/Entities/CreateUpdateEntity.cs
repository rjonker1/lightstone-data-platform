using UserManagement.Domain.Core.Commands;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities.Commands.Entities
{
    public class CreateUpdateEntity : DomainCommand
    {
        public Entity Entity;

        public CreateUpdateEntity(Entity entity)
        {
            Entity = entity;
        }
    }
}