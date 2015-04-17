using MemBus;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Entities;
using UserManagement.Domain.Entities.Commands.Roles;

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
            _bus.Publish(new CreateUpdateEntity(new Role("Owner"), "Create"));
            _bus.Publish(new CreateUpdateEntity(new Role("SuperUser"), "Create"));
            _bus.Publish(new CreateUpdateEntity(new Role("User"), "Create"));
            _bus.Publish(new CreateUpdateEntity(new Role("Admin"), "Create"));
            _bus.Publish(new CreateUpdateEntity(new Role("ProductManager"), "Create"));
            _bus.Publish(new CreateUpdateEntity(new Role("Support"), "Create"));
            _bus.Publish(new CreateUpdateEntity(new Role("AccountManager"), "Create"));
        }
    }
}