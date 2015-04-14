using System;
using System.Collections.Generic;
using System.Linq;
using RabbitMQ.Client;
using Workflow.Transactions.Shared.Queuing;
using Workflow.Transactions.Shared.QueueSetup;

namespace Workflow.Transactions.Shared.Configuration
{
    public class TransactionQueues
    {
        public static IAmAQueue[] Names
        {
            get
            {
                return new[]
                {
                    ConfigureTransactionWriteQueues.ForHost(),
                    ConfigureTransactionWriteQueues.ForAudit(),
                    ConfigureTransactionWriteQueues.ForErrors(),
                    ConfigureTransactionWriteQueues.ForRetries(),

                    ConfigureTransactionReadQueues.ForHost(),
                    ConfigureTransactionReadQueues.ForAudit(),
                    ConfigureTransactionReadQueues.ForErrors(),
                    ConfigureTransactionReadQueues.ForRetries(),

                    ConfigureTransactionForBillingCreatedQueue.ForHost()

                };
            }
        }

        public static IBindToAQueue[] QueuesForBinding
        {
            get
            {
                return new[]
                {

                    new BindToQueue(ConfigureTransactionReadQueues.ForHost(),
                        string.Empty,
                        ConfigureTransactionsExchangesToBind.ForReadHost().ExchangeName,
                        ConfigureTransactionsExchangesToBind.ForReadHost().RoutingKey) //,

                    //new BindToQueue(ConfigureTransactionForBillingCreatedQueue.ForHost(), string.Empty,
                    //    ConfigureTransactionsExchangesToBind.ForReadHost().ExchangeName,
                    //    ConfigureTransactionsExchangesToBind.ForReadHost().RoutingKey),
                };
            }
        }

        public static IAmAnExchange[] Exchanges
        {
            get
            {
                return ConfigureTransactionExchanges.ForEvents().ToArray();
            }
        }
    }

    public class ConfigureTransactionWriteQueues
    {
        public static Func<IAmAQueue> ForHost =
            () => new Queue("DataPlatform.Transactions.Host.Write", "DataPlatform.Transactions.Host.Write",
                string.Empty, ExchangeType.Fanout, QueueFunction.WriteQueue, QueueType.Host);

        public static Func<IAmAQueue> ForAudit = () => new Queue("DataPlatform.Transactions.Write.Audit",
            "DataPlatform.Transactions.Write.Audit", string.Empty, ExchangeType.Fanout, QueueFunction.WriteQueue,
            QueueType.Audit);

        public static Func<IAmAQueue> ForErrors = () => new Queue("DataPlatform.Transactions.Write.Error",
            "DataPlatform.Transactions.Write.Error", string.Empty, ExchangeType.Fanout, QueueFunction.WriteQueue,
            QueueType.Error);

        public static Func<IAmAQueue> ForRetries =
            () => new Queue("DataPlatform.Transactions.Host.Retries",
                "DataPlatform.Transactions.Host.Retries", string.Empty, ExchangeType.Fanout, QueueFunction.WriteQueue,
                QueueType.Retries);
    }

    public class ConfigureTransactionReadQueues
    {
        public static Func<IAmAQueue> ForHost =
            () => new Queue("DataPlatform.Transactions.Host.Read",
                "DataPlatform.Transactions.Host.Read", string.Empty, ExchangeType.Fanout,
                QueueFunction.ReadQueue, QueueType.Host);

        public static Func<IAmAQueue> ForAudit =
            () => new Queue("DataPlatform.Transactions.Read.Audit", "DataPlatform.Transactions.Read.Audit",
                string.Empty, ExchangeType.Fanout, QueueFunction.ReadQueue, QueueType.Audit);

        public static Func<IAmAQueue> ForErrors =
            () => new Queue("DataPlatform.Transactions.Read.Error", "DataPlatform.Transactions.Read.Error",
                string.Empty, ExchangeType.Fanout, QueueFunction.ReadQueue, QueueType.Error);

        public static Func<IAmAQueue> ForRetries =
            () => new Queue("DataPlatform.Transactions.Host.Read.Retries",
                "DataPlatform.Transactions.Host.Read.Retries", string.Empty, ExchangeType.Fanout,
                QueueFunction.ReadQueue, QueueType.Retries);
    }

    public class ConfigureTransactionForBillingCreatedQueue
    {
        public static Func<IAmAQueue> ForHost =
            () => new Queue("DataPlatform.Transactions.Billing", "DataPlatform.Transactions.Billing",
                string.Empty, ExchangeType.Fanout, QueueFunction.ReadQueue, QueueType.Host);
    }

    public class ConfigureTransactionsExchangesToBind
    {
        public static Func<IAmAnExchange> ForReadHost =
            () =>
                new Exchange("DataPlatform.Shared.Messaging:IPublishableMessage", ExchangeType.Fanout, string.Empty);
    }

    public class ConfigureTransactionExchanges
    {
        public static Func<IEnumerable<IAmAnExchange>> ForEvents = () =>
        {
            var type = typeof (DataPlatform.Shared.Messaging.IPublishableMessage);
            var exchanges = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(w => type.IsAssignableFrom(w) && w.IsClass)
                .Select(s => new Exchange(s.FullName, ExchangeType.Fanout, string.Empty)).ToList();

            exchanges.Add(new Exchange(ConfigureTransactionsExchangesToBind.ForReadHost().ExchangeName,
                ConfigureTransactionsExchangesToBind.ForReadHost().ExchangeType,
                ConfigureTransactionsExchangesToBind.ForReadHost().RoutingKey));

            return exchanges;
        };
    }
}
