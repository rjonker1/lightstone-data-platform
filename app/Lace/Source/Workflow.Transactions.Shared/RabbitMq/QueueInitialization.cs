using System;
using System.Linq;
using Common.Logging;
using Workflow.Transactions.Shared.Queuing;
using Workflow.Transactions.Shared.Configuration;

namespace Workflow.Transactions.Shared.RabbitMq
{
    public class QueueInitialization : IInitializeQueues
    {
        private readonly IConsumeQueue _consumer;
        private static readonly ILog Log = LogManager.GetLogger<QueueInitialization>();
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
                Log.InfoFormat("Attempting to add transaction queues. Number of queues to add {0} ",
                    TransactionQueues.Names.Count());
                foreach (var queue in TransactionQueues.Names)
                {
                    _consumer.AddQueue(queue.QueueName, queue.ExchangeName, queue.RoutingKey, queue.ExchangeType);
                }

                Log.InfoFormat(
                    "Attempting to add transaction queues that require binding. Number of queues to add {0} ",
                    TransactionQueues.QueuesForBinding.Count());
                foreach (var queue in TransactionQueues.QueuesForBinding)
                {
                    _consumer.AddExchangeBindingToQueue(queue.Queue, queue.ExchangeName, queue.RoutingKey);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat(
                    "An error occurred initializing the queues for the transaction data platform. Error {0}", ex.Message);
                QueuesInitialized = false;
            }
        }


        public void InitializeReadQueues()
        {
            try
            {
                Log.InfoFormat("Attempting to add transaction read queues. Number of queues to add {0} ",
                    TransactionQueues.Names.Count(w => w.QueueFunction == QueueFunction.ReadQueue));
                foreach (var queue in TransactionQueues.Names.Where(w => w.QueueFunction == (int)QueueFunction.ReadQueue))
                {
                    _consumer.AddQueue(queue.QueueName, queue.ExchangeName, queue.RoutingKey, queue.ExchangeType);
                }

                Log.InfoFormat(
                    "Attempting to add transaction queues that require binding. Number of queues to add {0} ",
                    TransactionQueues.QueuesForBinding.Count());
                foreach (var queue in TransactionQueues.QueuesForBinding)
                {
                    _consumer.AddExchangeBindingToQueue(queue.Queue, queue.ExchangeName, queue.RoutingKey);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat(
                    "An error occurred initializing the read queues for the transaction data platform. Error {0}", ex.Message);
                QueuesInitialized = false;
            }
        }

        public void InitializeWriteQueues()
        {
            try
            {
                Log.InfoFormat("Attempting to add transaction write queues. Number of queues to add {0} ",
                    TransactionQueues.Names.Count(w => w.QueueFunction == QueueFunction.WriteQueue));
                foreach (var queue in TransactionQueues.Names.Where(w => w.QueueFunction == QueueFunction.WriteQueue))
                {
                    _consumer.AddQueue(queue.QueueName, queue.ExchangeName, queue.RoutingKey, queue.ExchangeType);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat(
                    "An error occurred initializing the queues for the transaction data platform. Error {0}", ex.Message);
                QueuesInitialized = false;
            }
        }

        public void InitializeAllExchanges()
        {
            try
            {
                Log.InfoFormat("Attempting to add transaction exchanges for events. Number of exchanges to add {0} ",
                    TransactionQueues.Names.Count(w => w.QueueFunction == QueueFunction.WriteQueue));
                foreach (var exchange in TransactionQueues.Exchanges)
                {
                    _consumer.AddExchange(exchange.ExchangeName, exchange.ExchangeType);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat(
                    "An error occurred initializing the exchanges for the transaction data platform. Error {0}", ex.Message);
                QueuesInitialized = false;
            }
        }
    }
}
