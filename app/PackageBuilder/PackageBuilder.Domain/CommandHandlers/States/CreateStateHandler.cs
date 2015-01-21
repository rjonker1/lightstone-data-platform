using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
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
            {
                var exception = new LightstoneAutoException("State {0} already exists".FormatWith(command.Id, command.Name));
                this.Warn(() => exception);
                throw exception;                
            }

            var entity = new State(command.Id, command.Name, command.Alias);

            _repository.Save(entity);
        }
    }
}