using MemBus;
using UserManagement.Domain.Core.Helpers;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Entities;
using UserManagement.Domain.Entities.Commands.PlatformStatuses;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.CommandHandlers.PlatformStatuses
{
    public class ImportPlatformStatusHandler : AbstractMessageHandler<ImportPlatformStatus>
    {
        private readonly IBus _bus;

        public ImportPlatformStatusHandler(IBus bus)
        {
            _bus = bus;
        }

        public override void Handle(ImportPlatformStatus command)
        {
            _bus.Publish(new CreateUpdateEntity(new PlatformStatus("INCOMPLETE", PlatformStatusType.Incomplete), "Create"));
            _bus.Publish(new CreateUpdateEntity(new PlatformStatus("ACTIVATED", PlatformStatusType.Activated), "Create"));
            _bus.Publish(new CreateUpdateEntity(new PlatformStatus("LOCKED", PlatformStatusType.Locked), "Create"));
        }
    }
}