using UserManagement.Domain.Core.Commands;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities.Commands.Entities
{
    public class DeleteLookupEntity : DomainCommand
    {
        public Entity Entity;

        public DeleteLookupEntity(Entity entity)
        {
            Entity = entity;
        }
    }
}