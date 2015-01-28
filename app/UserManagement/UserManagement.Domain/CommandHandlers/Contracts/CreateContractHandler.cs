using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Contracts;

namespace UserManagement.Domain.CommandHandlers.Contracts
{
    public class CreateContractHandler : AbstractMessageHandler<CreateContract>
    {

        private readonly IRepository<Contract> _repository;

        public CreateContractHandler(IRepository<Contract> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateContract command)
        {

            _repository.Save(new Contract(command.Id, command.ContractCommencementDate, command.ContractName,
                                            command.LastUpdateBy, command.LastUpdateDate, command.ContactDetail, command.EnteredIntoBy, command.OnlineAcceptance, 
                                            command.RegisteredName, command.RegistrationNumber, command.Client, command.ContractType, command.EscalationType,
                                            command.ContractDuration));
        }
    }
}