using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.UserProfiles;

namespace UserManagement.Domain.CommandHandlers.UserProfiles
{
    public class CreateUserProfileHandler : AbstractMessageHandler<CreateUserProfile>
    {
        private readonly IRepository<UserProfile> _repository;

        public CreateUserProfileHandler(IRepository<UserProfile> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateUserProfile command)
        {
            _repository.Save(new UserProfile(command.Id, command.ContactNumber, command.FirstName, 
                                                command.IdNumber, command.Surname));
        }
    }
}