using Billing.Domain.Core.Entities;
using Billing.Domain.Core.MessageHandling;
using Billing.Domain.Core.Repositories;
using Billing.Domain.Entities.Commands.Entities;
using DataPlatform.Shared.Repositories;

namespace Billing.Domain.Entities
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