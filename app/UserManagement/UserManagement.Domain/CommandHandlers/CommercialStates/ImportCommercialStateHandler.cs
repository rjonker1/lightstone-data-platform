using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
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
            _handler.Handle(new ValueEntityDto("BILLABLE", typeof(CommercialState)));
            _handler.Handle(new ValueEntityDto("TRIAL", typeof(CommercialState)));
            _handler.Handle(new ValueEntityDto("INTERNAL", typeof(CommercialState)));
        }
    }
}