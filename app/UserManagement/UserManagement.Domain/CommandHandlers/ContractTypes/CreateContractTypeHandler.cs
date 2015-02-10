using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.ContractTypes;

namespace UserManagement.Domain.CommandHandlers.ContractTypes
{
    public class CreateContractTypeHandler : AbstractMessageHandler<CreateContractType>
    {
        private readonly INamedEntityRepository<ContractType> _repository;

        public CreateContractTypeHandler(INamedEntityRepository<ContractType> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateContractType command)
        {

            if (_repository.Exists(command.Id, command.Name)) return;

            _repository.Save(new ContractType(command.Name));
        }
    }
}