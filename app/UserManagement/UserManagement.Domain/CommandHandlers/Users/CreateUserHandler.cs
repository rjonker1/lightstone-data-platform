using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Users;

namespace UserManagement.Domain.CommandHandlers.Users
{
    public class CreateUserHandler : AbstractMessageHandler<CreateUser>
    {

        

        public override void Handle(CreateUser command)
        {

            var entity = new User(command.FirstCreateDate, command.LastUpdateBy, command.LastUpdateDate,
                command.Password, command.UserName, command.UserTypeId, command.IsActive);
        }
    }
}