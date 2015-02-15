using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities.Commands.Entities;

namespace UserManagement.Domain.CommandHandlers.Entities
{
    public class CreateUpdateEntityHandler : AbstractMessageHandler<CreateUpdateEntity>
    {
        private readonly IRepository<Entity> _repository;

        public CreateUpdateEntityHandler(IRepository<Entity> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateUpdateEntity command)
        {
            _repository.SaveOrUpdate(command.Entity);
        }
    }
}