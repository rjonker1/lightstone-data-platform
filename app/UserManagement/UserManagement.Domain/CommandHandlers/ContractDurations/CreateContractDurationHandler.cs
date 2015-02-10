using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.ContractDurations;

namespace UserManagement.Domain.CommandHandlers.ContractDurations
{
    public class CreateContractDurationHandler : AbstractMessageHandler<CreateContractDuration>
    {
        private readonly INamedEntityRepository<ContractDuration> _repository;

        public CreateContractDurationHandler(INamedEntityRepository<ContractDuration> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateContractDuration command)
        {
            if (_repository.Exists(command.Id, command.Name)) return;

            _repository.Save(new ContractDuration(command.Name));
        }
    }
}