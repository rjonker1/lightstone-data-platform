using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.PlatformStatuses;

namespace UserManagement.Domain.CommandHandlers.PlatformStatuses
{
    public class CreatePlatformStatusHandler : AbstractMessageHandler<CreatePlatformStatus>
    {
        private readonly INamedEntityRepository<PlatformStatus> _repository;

        public CreatePlatformStatusHandler(INamedEntityRepository<PlatformStatus> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreatePlatformStatus command)
        {
            if (_repository.Exists(command.Id, command.Name)) return;

            _repository.Save(new PlatformStatus(command.Name));
        }
    }
}