using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Roles;

namespace UserManagement.Domain.CommandHandlers.Roles
{
    public class CreateRoleHandler : AbstractMessageHandler<CreateRole>
    {
        private readonly INamedEntityRepository<Role> _repository;

        public CreateRoleHandler(INamedEntityRepository<Role> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateRole command)
        {
            if (_repository.Exists(command.Id, command.Name)) return;

            _repository.Save(new Role(command.Name));
        }
    }
}