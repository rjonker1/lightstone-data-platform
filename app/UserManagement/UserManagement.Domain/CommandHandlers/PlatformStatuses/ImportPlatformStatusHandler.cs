using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.PlatformStatuses;

namespace UserManagement.Domain.CommandHandlers.PlatformStatuses
{
    public class ImportPlatformStatusHandler : AbstractMessageHandler<ImportPlatformStatus>
    {
        private readonly IHandleMessages _handler;

        public ImportPlatformStatusHandler(IHandleMessages handler)
        {
            _handler = handler;
        }

        public override void Handle(ImportPlatformStatus command)
        {
            _handler.Handle(new ValueEntityDto("INCOMPLETE", typeof(PlatformStatus)));
            _handler.Handle(new ValueEntityDto("ACTIVATED", typeof(PlatformStatus)));
            _handler.Handle(new ValueEntityDto("LOCKED", typeof(PlatformStatus)));
        }
    }
}