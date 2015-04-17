using EasyNetQ;
using Shared.Messaging.Billing.Helpers;

namespace DataPlatform.Shared.Messaging.Billing.Messages
{
    [Queue("DataPlatform.Transactions.Billing", ExchangeName = "DataPlatform.Transactions.Billing")]
    public class EntityMessage: IPublishableMessage
    {
        public Entity Entity { get; set; }
    }
}