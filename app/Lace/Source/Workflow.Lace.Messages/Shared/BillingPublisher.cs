using System;
using Common.Logging;
using EasyNetQ;
using EasyNetQ.Topology;
using Workflow.Lace.Messages.Core;

namespace Workflow.Lace.Messages.Shared
{
    public class BillingPublisher : IPublishBillingMessages
    {
        private readonly IAdvancedBus _bus;
        private readonly IExchange _exchange;
        private readonly IQueue _queue;
        private readonly ILog _log;

        private const string Exchange = "DataPlatform.Transactions.Billing";
        private const string QueueName = "DataPlatform.Transactions.Billing";


        public BillingPublisher(IAdvancedBus bus)
        {
            _bus = bus;
            _exchange = _bus.ExchangeDeclare(Exchange,
                ExchangeType.Fanout);
            _queue = _bus.QueueDeclare(QueueName);
            _bus.Bind(_exchange, _queue, "");
            _log = LogManager.GetLogger(GetType());
        }

        public void SendToBus<T>(T message) where T : class
        {
            try
            {
                _bus.Publish<T>(_exchange, "", true, false, new Message<T>(message));
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error sending message to Billing Transation Bus: {0}",ex, ex.Message);
            }
        }
    }
}
