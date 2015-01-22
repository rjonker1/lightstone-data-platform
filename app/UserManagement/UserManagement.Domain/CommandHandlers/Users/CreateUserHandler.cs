using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Users;

namespace UserManagement.Domain.CommandHandlers.Users
{
    public class CreateUserHandler : AbstractMessageHandler<CreateUser>
    {

        private readonly IRepository<User> _repository;  

        public CreateUserHandler(IRepository<User> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateUser command)
        {

            _repository.Save(new User(command.FirstCreateDate, command.LastUpdateBy, command.LastUpdateDate,
                    command.Password, command.UserName, command.IsActive, command.ClientUser,
                    command.UserType, command.UserLinkedToCustomer, command.UserProfile, command.Roles));
        }
    }
}