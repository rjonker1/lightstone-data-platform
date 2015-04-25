using EasyNetQ;
using EasyNetQ.Topology;

namespace Workflow.DataProvider.Bus.Domain.Publisher
{
    public class DataProviderEventBus
    {
        private readonly IAdvancedBus _advancedBus;
        private IExchange _exchange;
        private IQueue _queue;

        public DataProviderEventBus(IAdvancedBus bus)
        {
            _advancedBus = bus;
        }

        public void Send<T>(T message, string exchangeName, string queueName) where T : class
        {
            _exchange = _advancedBus.ExchangeDeclare(exchangeName.Length > 0 ? exchangeName : "DEFAULTED_NAME",
                ExchangeType.Fanout);
            _queue = _advancedBus.QueueDeclare(queueName.Length > 0 ? queueName : "DEFAULTED_NAME");
            _advancedBus.Bind(_exchange, _queue, "");

            _advancedBus.Publish<T>(_exchange, "", true, false, new Message<T>(message));
        }
    }
}
