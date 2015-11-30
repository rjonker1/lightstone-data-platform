using MemBus;
using UserManagement.Domain.Core.Helpers;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Contracts;
using UserManagement.Domain.Entities.Commands.Entities;

namespace UserManagement.Domain.CommandHandlers.Contracts
{
    public class ImportContractBundleHandler : AbstractMessageHandler<ImportContractBundle>
    {
        private readonly IBus _bus;

        public ImportContractBundleHandler(IBus bus)
        {
            _bus = bus;
        }

        public override void Handle(ImportContractBundle command)
        {
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new ContractBundle(235, 5, "Bundle 1"), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new ContractBundle(500, 11, "Bundle 2"), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new ContractBundle(730, 17, "Bundle 3"), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new ContractBundle(1000, 24, "Bundle 4"), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new ContractBundle(2000, 50, "Bundle 5"), "Create")));

            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new ContractBundle(10000, 0, "Flat fee monthly 1"), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new ContractBundle(12000, 0, "Flat fee monthly 2"), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new ContractBundle(15000, 0, "Flat fee monthly 3"), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new ContractBundle(18000, 0, "Flat fee monthly 4"), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new ContractBundle(20000, 0, "Flat fee monthly 5"), "Create")));
        }
    }
}