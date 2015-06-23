using MemBus;
using UserManagement.Domain.Core.Helpers;
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
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new Role(RoleType.Owner.ToString()), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new Role(RoleType.SuperUser.ToString()), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new Role(RoleType.User.ToString()), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new Role(RoleType.Admin.ToString()), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new Role(RoleType.ProductManager.ToString()), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new Role(RoleType.Support.ToString()), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new Role(RoleType.AccountManager.ToString()), "Create")));
        }
    }
}