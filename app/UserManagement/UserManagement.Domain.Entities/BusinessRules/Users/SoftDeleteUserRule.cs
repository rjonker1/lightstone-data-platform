using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.BusinessRules.Users
{
    public class SoftDeleteUserRule : DomainCommand
    {
         
        public User Entity;

        public SoftDeleteUserRule(User user)
        {
            Entity = user;
        }
    }
}