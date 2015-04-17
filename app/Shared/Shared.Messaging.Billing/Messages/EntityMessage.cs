using DataPlatform.Shared.Messaging.Billing.Helpers;
using EasyNetQ;

namespace DataPlatform.Shared.Messaging.Billing.Messages
{
    [Queue("DataPlatform.Transactions.Billing", ExchangeName = "DataPlatform.Transactions.Billing")]
    public class EntityMessage: IPublishableMessage
    {
        public Entity Entity { get; set; }
    }
}