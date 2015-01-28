using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities.Commands.CommercialStates;

namespace UserManagement.Domain.CommandHandlers.CommercialStates
{
    public class ImportCommercialStateHandler : AbstractMessageHandler<ImportCommercialState>
    {

        private readonly IHandleMessages _handler;

        public ImportCommercialStateHandler(IHandleMessages handler)
        {
            _handler = handler;
        }

        public override void Handle(ImportCommercialState command)
        {

            _handler.Handle(new CreateCommercialState("BILLABLE"));
            _handler.Handle(new CreateCommercialState("TRIAL"));
            _handler.Handle(new CreateCommercialState("INTERNAL"));
        }
    }
}