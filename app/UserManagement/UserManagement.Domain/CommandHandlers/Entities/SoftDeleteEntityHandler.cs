using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.BusinessRules;
using UserManagement.Domain.Entities.Commands.Entities;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Domain.CommandHandlers.Entities
{
    public class SoftDeleteEntityHandler : AbstractMessageHandler<SoftDeleteEntity>
    {

        private readonly IRepository<Entity> _repository;

        private readonly IHandleMessages _handler;

        public SoftDeleteEntityHandler(IRepository<Entity> repository, IHandleMessages handler)
        {
            _repository = repository;
            _handler = handler;
        }

        public override void Handle(SoftDeleteEntity command)
        {

            var brv = new BusinessRulesValidator(_handler);
            brv.CheckRules(command.Entity, "Delete");

            _repository.SaveOrUpdate(command.Entity);
        }
    }
}