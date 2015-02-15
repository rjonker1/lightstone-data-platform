using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.EscalationTypes;

namespace UserManagement.Domain.CommandHandlers.EscalationTypes
{
    public class CreateEscalationTypeHandler : AbstractMessageHandler<CreateEscalationType>
    {
        private readonly INamedEntityRepository<EscalationType> _repository;

        public CreateEscalationTypeHandler(INamedEntityRepository<EscalationType> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateEscalationType command)
        {
            if (_repository.Exists(command.Id, command.Name)) return;

            _repository.Save(new EscalationType(command.Name));
        }
    }
}