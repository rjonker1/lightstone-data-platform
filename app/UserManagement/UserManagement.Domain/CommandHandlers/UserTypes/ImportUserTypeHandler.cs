using MemBus;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Entities;
using UserManagement.Domain.Entities.Commands.UserTypes;

namespace UserManagement.Domain.CommandHandlers.UserTypes
{
    public class ImportUserTypeHandler : AbstractMessageHandler<ImportUserType>
    {
        private readonly IBus _bus;

        public ImportUserTypeHandler(IBus bus)
        {
            _bus = bus;
        }

        public override void Handle(ImportUserType command)
        {
            _bus.Publish(new CreateUpdateEntity(new UserType("Internal"), "Create"));
            _bus.Publish(new CreateUpdateEntity(new UserType("External"), "Create"));
        }
    }
}