using UserManagement.Domain.Core.MessageHandling;
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
            
            _handler.Handle(new CreateEscalationType("Annual % all products"));
            _handler.Handle(new CreateEscalationType("Annual % per product"));
            _handler.Handle(new CreateEscalationType("As per LSA"));
        }
    }
}