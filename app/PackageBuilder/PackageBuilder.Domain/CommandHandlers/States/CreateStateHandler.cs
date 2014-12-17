using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Domain.Entities.States.Commands;
using PackageBuilder.Domain.Entities.States.WriteModels;
using PackageBuilder.Infrastructure.Repositories;

namespace PackageBuilder.Domain.CommandHandlers.States
{
    public class CreateStateHandler : AbstractMessageHandler<CreateState>
    {
        private readonly IStateRepository _repository;

        public CreateStateHandler(IStateRepository repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateState command)
        {
            if (_repository.Exists(command.Id, command.Name))
                return;

            var entity = new State(command.Id, command.Name, command.Alias);

            _repository.Save(entity);
        }
    }
}