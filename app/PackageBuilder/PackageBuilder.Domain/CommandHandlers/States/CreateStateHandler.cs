using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
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
                throw new LightstoneAutoException("An state with the name {0} already exists".FormatWith(command.Name));

            var entity = new State(command.Id, command.Name, command.Alias);

            _repository.Save(entity);
        }
    }
}