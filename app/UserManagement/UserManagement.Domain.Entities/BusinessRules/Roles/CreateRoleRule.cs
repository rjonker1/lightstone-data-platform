using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.BusinessRules.Roles
{
    public class CreateRoleRule : DomainCommand
    {
        public Role Role;

        public CreateRoleRule(Role role)
        {
            Role = role;
        }
    }
}