using UserManagement.Domain.Core.MessageHandling;
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
           
            _handler.Handle(new CreateContractType("Master Agreement"));
            _handler.Handle(new CreateContractType("Online Agreement"));
            _handler.Handle(new CreateContractType("Client Agreement"));
        }
    }
}