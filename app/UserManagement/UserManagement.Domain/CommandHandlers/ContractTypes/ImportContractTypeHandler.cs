using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.ContractTypes;

namespace UserManagement.Domain.CommandHandlers.ContractTypes
{
    public class ImportContractTypeHandler : AbstractMessageHandler<ImportContractType>
    {
        private readonly IHandleMessages _handler;

        public ImportContractTypeHandler(IHandleMessages handler)
        {
            _handler = handler;
        }

        public override void Handle(ImportContractType command)
        {
            _handler.Handle(new ValueEntityDto("Master Agreement", typeof(ContractType)));
            _handler.Handle(new ValueEntityDto("Online Agreement", typeof(ContractType)));
            _handler.Handle(new ValueEntityDto("Client Agreement", typeof(ContractType)));
        }
    }
}