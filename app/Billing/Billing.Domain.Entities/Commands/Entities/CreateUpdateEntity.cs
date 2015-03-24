using Billing.Domain.Core.Commands;
using Billing.Domain.Core.Entities;
using DataPlatform.Shared.Messaging;

namespace Billing.Domain.Entities.Commands.Entities
{
    public class CreateUpdateEntity : DomainCommand, IPublishableMessage
    {
        public Entity Entity;

        public CreateUpdateEntity(Entity entity)
        {
            Entity = entity;
        }
    }
}