using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.Entities
{
    public class CreateUpdateEntity : DomainCommand
    {
        public Entity Entity;
        public string Function;

        public CreateUpdateEntity(Entity entity, string function)
        {
            Entity = entity;
            Function = function;
        }
    }
}