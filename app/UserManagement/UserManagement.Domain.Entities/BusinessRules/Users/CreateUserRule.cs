using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.BusinessRules.Users
{
    public class CreateUserRule : DomainCommand
    {

        public User Entity;

        public CreateUserRule(User entity)
        {
            Entity = entity;
        }
    }
}