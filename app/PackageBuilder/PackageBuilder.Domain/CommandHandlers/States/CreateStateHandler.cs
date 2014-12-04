using System.Linq;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.States.Commands;
using PackageBuilder.Domain.Entities.States.WriteModels;

namespace PackageBuilder.Domain.CommandHandlers.States
{
    public class CreateStateHandler : AbstractMessageHandler<CreateState>
    {
        private readonly IRepository<State> _repository;

        public CreateStateHandler(IRepository<State> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateState command)
        {
            if (_repository.FirstOrDefault(x => x.Name == command.Name) != null)
                return;

            var entity = new State(command.Id, command.Name, command.Alias);

            _repository.Save(entity);
        }
    }
}