using MemBus;
using UserManagement.Domain.Core.Helpers;
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
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new Province("Eastern Cape"), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new Province("Free State"), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new Province("Gauteng"), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new Province("KwaZulu-Natal"), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new Province("Limpopo"), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new Province("Mpumalanga"), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new Province("North West"), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new Province("Northern Cape"), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new Province("Western Cape"), "Create")));
        }
    }
}