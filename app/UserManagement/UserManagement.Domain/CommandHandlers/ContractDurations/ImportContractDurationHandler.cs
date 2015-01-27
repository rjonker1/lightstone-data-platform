using UserManagement.Domain.Core.MessageHandling;
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
            
            _handler.Handle(new CreateContractDuration("Rolling MoM"));
            _handler.Handle(new CreateContractDuration("Custom"));
            _handler.Handle(new CreateContractDuration("6 Months"));
            _handler.Handle(new CreateContractDuration("12 Months"));
            _handler.Handle(new CreateContractDuration("18 Months"));
            _handler.Handle(new CreateContractDuration("24 Months"));
        }
    }
}