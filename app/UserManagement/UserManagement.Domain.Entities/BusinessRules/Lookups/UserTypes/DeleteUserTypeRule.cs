using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.BusinessRules.Lookups.UserTypes
{
    public class DeleteUserTypeRule : DomainCommand
    {

        public UserType Entity;

        public DeleteUserTypeRule(UserType entity)
        {
            Entity = entity;
        }
    }
}