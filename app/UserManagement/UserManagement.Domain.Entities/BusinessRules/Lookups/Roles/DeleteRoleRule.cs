using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.BusinessRules.Lookups.Roles
{
    public class DeleteRoleRule : DomainCommand
    {

        public Role Entity;

        public DeleteRoleRule(Role entity)
        {
            Entity = entity;
        }
    }
}