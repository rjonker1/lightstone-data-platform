using DataPlatform.Shared.Messaging;
using Shared.Messaging.Billing.Helpers;

namespace Shared.Messaging.Billing.Messages
{
    public class EntityMessage: IPublishableMessage
    {
        public Entity Entity { get; set; }
    }
}