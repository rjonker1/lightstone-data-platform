using Workflow.Lace.Shared.Queuing;

namespace Workflow.Lace.Shared.QueueSetup
{
    public class Exchange : IAmAnExchange
    {
        public string ExchangeName { get; private set; }
        public string ExchangeType { get; private set; }
        public string RoutingKey { get; private set; }

        public Exchange(string exchangeName, string exchangeType, string routingKey)
        {
            ExchangeName = exchangeName;
            ExchangeType = exchangeType;
            RoutingKey = routingKey;
        }
    }
}
