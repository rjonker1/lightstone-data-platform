using MemBus;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.ContractDurations;
using UserManagement.Domain.Entities.Commands.Entities;

namespace UserManagement.Domain.CommandHandlers.ContractDurations
{
    public class ImportContractDurationHandler : AbstractMessageHandler<ImportContractDuration>
    {
        private readonly IBus _bus;

        public ImportContractDurationHandler(IBus bus)
        {
            _bus = bus;
        }

        public override void Handle(ImportContractDuration command)
        {
            _bus.Publish(new CreateUpdateEntity(new ContractDuration("Rolling MoM"), "Create"));
            _bus.Publish(new CreateUpdateEntity(new ContractDuration("Custom"), "Create"));
            _bus.Publish(new CreateUpdateEntity(new ContractDuration("6 Months"), "Create"));
            _bus.Publish(new CreateUpdateEntity(new ContractDuration("12 Months"), "Create"));
            _bus.Publish(new CreateUpdateEntity(new ContractDuration("18 Months"), "Create"));
            _bus.Publish(new CreateUpdateEntity(new ContractDuration("24 Months"), "Create"));
        }
    }
}