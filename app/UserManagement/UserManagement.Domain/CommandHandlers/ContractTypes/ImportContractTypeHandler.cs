using MemBus;
using UserManagement.Domain.Core.Helpers;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.ContractTypes;
using UserManagement.Domain.Entities.Commands.Entities;

namespace UserManagement.Domain.CommandHandlers.ContractTypes
{
    public class ImportContractTypeHandler : AbstractMessageHandler<ImportContractType>
    {
        private readonly IBus _bus;

        public ImportContractTypeHandler(IBus bus)
        {
            _bus = bus;
        }

        public override void Handle(ImportContractType command)
        {
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new ContractType("Master Agreement"), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new ContractType("Online Agreement"), "Create")));
            ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new ContractType("Client Agreement"), "Create")));
        }
    }
}