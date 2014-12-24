using System;
using System.Linq;
using Common.Logging;
using Monitoring.Queuing.Configuration;
using Monitoring.Queuing.Contracts;

namespace Monitoring.Queuing.RabbitMq
{
    public class QueueInitialization : IInitializeQueues
    {
        private readonly IConsumeQueue _consumer;
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        public bool QueuesInitialized { get; private set; }

        public QueueInitialization(IConsumeQueue consumer)
        {
            _consumer = consumer;
            _consumer.Connect("localhost", "admin", "changeit");
        }

        public void InitializeAllQueues()
        {
            try
            {
                Log.InfoFormat("Attempting to add monitoring queues. Number of queues to add {0} ",
                    MonitoringQueues.Names.Count());
                foreach (var queue in MonitoringQueues.Names)
                {
                    _consumer.AddQueue(queue.QueueName, queue.ExchangeName, queue.RoutingKey, queue.ExchangeType);
                }

                Log.InfoFormat(
                    "Attempting to add monitoring queues that require binding. Number of queues to add {0} ",
                    MonitoringQueues.QueuesForBinding.Count());
                foreach (var queue in MonitoringQueues.QueuesForBinding)
                {
                    _consumer.AddExchangeBindingToQueue(queue.Queue, queue.ExchangeName, queue.RoutingKey);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat(
                    "An error occurred initializing the queues for the monitoring data platform. Error {0}", ex.Message);
                QueuesInitialized = false;
            }
        }


        public void InitializeReadQueues()
        {
            try
            {
                Log.InfoFormat("Attempting to add monitoring read queues. Number of queues to add {0} ",
                    MonitoringQueues.Names.Count(w => w.QueueFunction == QueueFunction.ReadQueue));
                foreach (var queue in MonitoringQueues.Names.Where(w => w.QueueFunction == (int) QueueFunction.ReadQueue))
                {
                    _consumer.AddQueue(queue.QueueName, queue.ExchangeName, queue.RoutingKey, queue.ExchangeType);
                }

                Log.InfoFormat(
                    "Attempting to add monitoring queues that require binding. Number of queues to add {0} ",
                    MonitoringQueues.QueuesForBinding.Count());
                foreach (var queue in MonitoringQueues.QueuesForBinding)
                {
                   _consumer.AddExchangeBindingToQueue(queue.Queue, queue.ExchangeName, queue.RoutingKey);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat(
                    "An error occurred initializing the read queues for the monitoring data platform. Error {0}", ex.Message);
                QueuesInitialized = false;
            }
        }

        public void InitializeWriteQueues()
        {
            try
            {
                Log.InfoFormat("Attempting to add monitoring write queues. Number of queues to add {0} ",
                    MonitoringQueues.Names.Count(w => w.QueueFunction == QueueFunction.WriteQueue));
                foreach (var queue in MonitoringQueues.Names.Where(w => w.QueueFunction == QueueFunction.WriteQueue))
                {
                    _consumer.AddQueue(queue.QueueName, queue.ExchangeName, queue.RoutingKey, queue.ExchangeType);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat(
                    "An error occurred initializing the queues for the monitoring data platform. Error {0}", ex.Message);
                QueuesInitialized = false;
            }
        }

        public void InitializeAllExchanges()
        {
            try
            {
                Log.InfoFormat("Attempting to add monitoring exchanges for events. Number of exchanges to add {0} ",
                    MonitoringQueues.Names.Count(w => w.QueueFunction == QueueFunction.WriteQueue));
                foreach (var exchange in MonitoringQueues.Exchanges)
                {
                    _consumer.AddExchange(exchange.ExchangeName, exchange.ExchangeType);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat(
                    "An error occurred initializing the exchanges for the monitoring data platform. Error {0}", ex.Message);
                QueuesInitialized = false;
            }
        }
    }
}
