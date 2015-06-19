using MemBus;
using UserManagement.Domain.Core.Helpers;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.CommercialStates;
using UserManagement.Domain.Entities.Commands.Entities;

namespace UserManagement.Domain.CommandHandlers.CommercialStates
{
    public class ImportCommercialStateHandler : AbstractMessageHandler<ImportCommercialState>
    {
        private readonly IBus _bus;

        public ImportCommercialStateHandler(IBus bus)
        {
            _bus = bus;
        }

        public override void Handle(ImportCommercialState command)
        {
            _bus.Publish(new CreateUpdateEntity(new CommercialState("BILLABLE"), "Create"));
            _bus.Publish(new CreateUpdateEntity(new CommercialState("TRIAL"), "Create"));
            _bus.Publish(new CreateUpdateEntity(new CommercialState("INTERNAL"), "Create"));
        }
    }
}