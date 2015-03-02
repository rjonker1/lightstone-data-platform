using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
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
            _handler.Handle(new ValueEntityDto("Within CAS", typeof(CreateSource)));
            _handler.Handle(new ValueEntityDto("Web Signup", typeof(CreateSource)));
            _handler.Handle(new ValueEntityDto("Mobile Signup", typeof(CreateSource)));
            _handler.Handle(new ValueEntityDto("Vendor Platform Signup", typeof(CreateSource)));
        }
    }
}