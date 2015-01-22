using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities.Commands.UserProfiles;

namespace UserManagement.Domain.CommandHandlers.UserProfiles
{
    public class CreateUserProfileHandler : AbstractMessageHandler<CreateUserProfile>
    {
        public override void Handle(CreateUserProfile command)
        {
            throw new System.NotImplementedException();
        }
    }
}