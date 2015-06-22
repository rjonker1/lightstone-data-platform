using MemBus;
using UserManagement.Domain.Core.Helpers;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.CreateSources;
using UserManagement.Domain.Entities.Commands.Entities;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.CommandHandlers.CreateSources
{
    public class ImportCreateSourceHandler : AbstractMessageHandler<ImportCreateSource>
    {
        private readonly IBus _bus;

        public ImportCreateSourceHandler(IBus bus)
        {
            _bus = bus;
        }

        public override void Handle(ImportCreateSource command)
        {
            _bus.Publish(new CreateUpdateEntity(new CreateSource("Within CAS", CreateSourceType.UserManagement), "Create"));
            _bus.Publish(new CreateUpdateEntity(new CreateSource("Web Signup", CreateSourceType.Web), "Create"));
            _bus.Publish(new CreateUpdateEntity(new CreateSource("Mobile Signup", CreateSourceType.Mobile), "Create"));
            _bus.Publish(new CreateUpdateEntity(new CreateSource("Vendor Platform Signup", CreateSourceType.Vendor), "Create"));
        }
    }
}