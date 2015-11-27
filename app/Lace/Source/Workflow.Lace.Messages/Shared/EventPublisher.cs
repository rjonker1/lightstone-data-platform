﻿using System;
using Common.Logging;
using EasyNetQ;
using EasyNetQ.Topology;
using Workflow.Lace.Messages.Core;

namespace Workflow.Lace.Messages.Shared
{
    public class EventPublisher : IPublishEventMessages
    {
        // private readonly IBus _bus;
        private readonly IAdvancedBus _bus;
        private readonly IExchange _exchange;
        private readonly IQueue _queue;
        private static readonly ILog Log = LogManager.GetLogger<WorkflowCommandPublisher>();

        private const string Exchange = "DataPlatform.DataProvider.Receiver";
        private const string QueueName = "DataPlatform.DataProvider.Receiver";


        public EventPublisher(IAdvancedBus bus)
        {
            _bus = bus;
            _exchange = _bus.ExchangeDeclare(Exchange,
                ExchangeType.Fanout);
            _queue = _bus.QueueDeclare(QueueName);
            _bus.Bind(_exchange, _queue, "");
        }

        public void SendToBus<T>(T message) where T : class
        {
            try
            {
                _bus.Publish<T>(_exchange, "", true, false, new Message<T>(message));
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error sending event message to Data Provider Workflow Bus: {0}", ex.Message);
            }
        }
    }
}
