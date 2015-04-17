using MemBus;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Entities;
using UserManagement.Domain.Entities.Commands.EscalationTypes;

namespace UserManagement.Domain.CommandHandlers.EscalationTypes
{
    public class ImportEscalationTypeHandler : AbstractMessageHandler<ImportEscalationType>
    {
        private readonly IBus _bus;

        public ImportEscalationTypeHandler(IBus bus)
        {
            _bus = bus;
        }

        public override void Handle(ImportEscalationType command)
        {
            _bus.Publish(new CreateUpdateEntity(new EscalationType("Annual % all products"), "Create"));
            _bus.Publish(new CreateUpdateEntity(new EscalationType("Annual % per product"), "Create"));
            _bus.Publish(new CreateUpdateEntity(new EscalationType("As per LSA"), "Create"));
        }
    }
}