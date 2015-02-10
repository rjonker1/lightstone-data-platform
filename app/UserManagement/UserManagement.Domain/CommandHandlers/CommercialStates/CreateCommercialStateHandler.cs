using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.CommercialStates;

namespace UserManagement.Domain.CommandHandlers.CommercialStates
{
    public class CreateCommercialStateHandler : AbstractMessageHandler<CreateCommercialState>
    {
        private readonly INamedEntityRepository<CommercialState> _repository;

        public CreateCommercialStateHandler(INamedEntityRepository<CommercialState> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateCommercialState command)
        {
            if (_repository.Exists(command.Id, command.Name)) return;

            _repository.Save(new CommercialState(command.Name));
        }
    }
}