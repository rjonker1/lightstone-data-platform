using UserManagement.Domain.Core.MessageHandling;
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

            _handler.Handle(new CreatePlatformStatus("INCOMPLETE"));
            _handler.Handle(new CreatePlatformStatus("ACTIVATED"));
            _handler.Handle(new CreatePlatformStatus("LOCKED"));
        }
    }
}