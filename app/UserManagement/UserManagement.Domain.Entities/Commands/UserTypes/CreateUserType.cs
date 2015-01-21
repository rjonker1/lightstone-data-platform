using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.UserTypes
{
    public class CreateUserType : IDomainCommand
    {
        public string Value;

        public CreateUserType(string value)
        {
            Value = value;
        }
    }
}