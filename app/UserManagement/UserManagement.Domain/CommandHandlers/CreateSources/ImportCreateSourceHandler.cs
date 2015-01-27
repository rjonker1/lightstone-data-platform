using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities.Commands.CreateSources;

namespace UserManagement.Domain.CommandHandlers.CreateSources
{
    public class ImportCreateSourceHandler : AbstractMessageHandler<ImportCreateSource>
    {

        private readonly IHandleMessages _handler;

        public ImportCreateSourceHandler(IHandleMessages handler)
        {
            _handler = handler;
        }

        public override void Handle(ImportCreateSource command)
        {

            _handler.Handle(new CreateCreateSource("Within CAS"));
            _handler.Handle(new CreateCreateSource("Web Signup"));
            _handler.Handle(new CreateCreateSource("Mobile Signup"));
            _handler.Handle(new CreateCreateSource("Vendor Platform Signup"));
        }
    }
}