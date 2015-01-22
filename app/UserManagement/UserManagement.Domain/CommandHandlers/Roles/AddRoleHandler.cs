using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Roles;

namespace UserManagement.Domain.CommandHandlers.Roles
{
    public class AddRoleHandler : AbstractMessageHandler<AddRole>
    {
        private readonly IRepository<Role> _repository;

        public AddRoleHandler(IRepository<Role> repository)
        {
            _repository = repository;
        }

        public override void Handle(AddRole command)
        {
            var userRole = new Role(command.Id, command.Name);
            _repository.SaveOrUpdate(userRole);
        }
    }
}