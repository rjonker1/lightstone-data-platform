using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.CreateSources;

namespace UserManagement.Domain.CommandHandlers.CreateSources
{
    public class CreateCreateSourceHandler : AbstractMessageHandler<CreateCreateSource>
    {
        private readonly INamedEntityRepository<CreateSource> _repository;

        public CreateCreateSourceHandler(INamedEntityRepository<CreateSource> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateCreateSource command)
        {
            if (_repository.Exists(command.Id, command.Name)) return;
            
            _repository.Save(new CreateSource(command.Name));
        }
    }
}