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
            _repository.Save(new User(command.FirstName, command.LastName, command.IdNumber, command.ContactNumber, command.UserName, command.Password, command.IsActive, command.UserType, command.Roles));
        }
    }
}