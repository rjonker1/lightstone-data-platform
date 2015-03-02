using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.EscalationTypes;

namespace UserManagement.Domain.CommandHandlers.EscalationTypes
{
    public class ImportEscalationTypeHandler : AbstractMessageHandler<ImportEscalationType>
    {
        private readonly IHandleMessages _handler;

        public ImportEscalationTypeHandler(IHandleMessages handler)
        {
            _handler = handler;
        }

        public override void Handle(ImportEscalationType command)
        {
            _handler.Handle(new ValueEntityDto("Annual % all products", typeof(EscalationType)));
            _handler.Handle(new ValueEntityDto("Annual % per product", typeof(EscalationType)));
            _handler.Handle(new ValueEntityDto("As per LSA", typeof(EscalationType)));
        }
    }
}