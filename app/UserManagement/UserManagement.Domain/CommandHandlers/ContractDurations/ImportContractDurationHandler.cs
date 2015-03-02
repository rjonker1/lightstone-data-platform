using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.ContractDurations;

namespace UserManagement.Domain.CommandHandlers.ContractDurations
{
    public class ImportContractDurationHandler : AbstractMessageHandler<ImportContractDuration>
    {
        private readonly IHandleMessages _handler;

        public ImportContractDurationHandler(IHandleMessages handler)
        {
            _handler = handler;
        }

        public override void Handle(ImportContractDuration command)
        {
            _handler.Handle(new ValueEntityDto("Rolling MoM", typeof(ContractDuration)));
            _handler.Handle(new ValueEntityDto("Custom", typeof(ContractDuration)));
            _handler.Handle(new ValueEntityDto("6 Months", typeof(ContractDuration)));
            _handler.Handle(new ValueEntityDto("12 Months", typeof(ContractDuration)));
            _handler.Handle(new ValueEntityDto("18 Months", typeof(ContractDuration)));
            _handler.Handle(new ValueEntityDto("24 Months", typeof(ContractDuration)));
        }
    }
}