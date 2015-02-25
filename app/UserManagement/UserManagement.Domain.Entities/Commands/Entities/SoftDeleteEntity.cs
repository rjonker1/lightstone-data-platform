using UserManagement.Domain.Core.Commands;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities.Commands.Entities
{
    public class SoftDeleteEntity : DomainCommand
    {
        public Entity Entity;
        public string Function;

        public SoftDeleteEntity(Entity entity, string function)
        {
            Entity = entity;
            Function = function;
        }
    }
}