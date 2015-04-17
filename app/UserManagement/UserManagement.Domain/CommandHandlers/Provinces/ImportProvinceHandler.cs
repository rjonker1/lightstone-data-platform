using MemBus;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Entities;
using UserManagement.Domain.Entities.Commands.Provinces;

namespace UserManagement.Domain.CommandHandlers.Provinces
{
    public class ImportProvinceHandler : AbstractMessageHandler<ImportProvince>
    {
        private readonly IBus _bus;

        public ImportProvinceHandler(IBus bus)
        {
            _bus = bus;
        }

        public override void Handle(ImportProvince command)
        {
            _bus.Publish(new CreateUpdateEntity(new Province("Eastern Cape"), "Create"));
            _bus.Publish(new CreateUpdateEntity(new Province("Free State"), "Create"));
            _bus.Publish(new CreateUpdateEntity(new Province("Gauteng"), "Create"));
            _bus.Publish(new CreateUpdateEntity(new Province("KwaZulu-Natal"), "Create"));
            _bus.Publish(new CreateUpdateEntity(new Province("Limpopo"), "Create"));
            _bus.Publish(new CreateUpdateEntity(new Province("Mpumalanga"), "Create"));
            _bus.Publish(new CreateUpdateEntity(new Province("North West"), "Create"));
            _bus.Publish(new CreateUpdateEntity(new Province("Northern Cape"), "Create"));
            _bus.Publish(new CreateUpdateEntity(new Province("Western Cape"), "Create"));
        }
    }
}