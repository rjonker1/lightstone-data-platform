using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities.Commands.Entities;

namespace UserManagement.Domain.CommandHandlers.Entities
{
    public class SoftDeleteEntityHandler : AbstractMessageHandler<SoftDeleteEntity>
    {

        private readonly IRepository<Entity> _repository;

        public override void Handle(SoftDeleteEntity command)
        {
            throw new System.NotImplementedException();
        }
    }
}