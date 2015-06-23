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
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new ContractBundle(1000, 200, "Bundle 1"), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new ContractBundle(3500, 600, "Bundle 2"), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new ContractBundle(6000, 1200, "Bundle 3"), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new ContractBundle(17500, 3500, "Bundle 4"), "Create")));
        }
    }
}