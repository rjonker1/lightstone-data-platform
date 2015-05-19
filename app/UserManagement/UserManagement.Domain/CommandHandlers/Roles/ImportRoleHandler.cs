using MemBus;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Entities;
using UserManagement.Domain.Entities.Commands.Roles;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.CommandHandlers.Roles
{
    public class ImportRoleHandler : AbstractMessageHandler<ImportRole>
    {
        private readonly IBus _bus;

        public ImportRoleHandler(IBus bus)
        {
            _bus = bus;
        }

        public override void Handle(ImportRole command)
        {
            _bus.Publish(new CreateUpdateEntity(new Role(RoleType.Owner.ToString()), "Create"));
            _bus.Publish(new CreateUpdateEntity(new Role(RoleType.SuperUser.ToString()), "Create"));
            _bus.Publish(new CreateUpdateEntity(new Role(RoleType.User.ToString()), "Create"));
            _bus.Publish(new CreateUpdateEntity(new Role(RoleType.Admin.ToString()), "Create"));
            _bus.Publish(new CreateUpdateEntity(new Role(RoleType.ProductManager.ToString()), "Create"));
            _bus.Publish(new CreateUpdateEntity(new Role(RoleType.Support.ToString()), "Create"));
            _bus.Publish(new CreateUpdateEntity(new Role(RoleType.AccountManager.ToString()), "Create"));
        }
    }
}