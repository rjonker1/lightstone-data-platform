using System;
using System.Collections.Generic;
using System.Linq;
using RabbitMQ.Client;
using Workflow.Lace.Shared.QueueSetup;
using Workflow.Lace.Shared.Queuing;

namespace Workflow.Lace.Shared.Configuration
{
    public class DataProviderQueues
    {
        public static IAmAQueue[] Names
        {
            get
            {
                return new[]
                {
                    ConfigureDataProviderWriteQueues.ForHost(),
                    ConfigureDataProviderWriteQueues.ForAudit(),
                    ConfigureDataProviderWriteQueues.ForErrors(),
                    ConfigureDataProviderWriteQueues.ForRetries(),

                    ConfigureDataProviderReadQueues.ForHost(),
                    ConfigureDataProviderReadQueues.ForAudit(),
                    ConfigureDataProviderReadQueues.ForErrors(),
                    ConfigureDataProviderReadQueues.ForRetries()

                };
            }
        }

        public static IBindToAQueue[] QueuesForBinding
        {
            get
            {
                return new[]
                {

                    new BindToQueue(ConfigureDataProviderReadQueues.ForHost(),
                        string.Empty,
                        ConfigureDataProviderExchangesToBind.ForReadHost().ExchangeName,
                        ConfigureDataProviderExchangesToBind.ForReadHost().RoutingKey)
                };
            }
        }

        public static IAmAnExchange[] Exchanges
        {
            get
            {
                return ConfigureDataProviderExchanges.ForEvents().ToArray();
            }
        }
    }

    public class ConfigureDataProviderWriteQueues
    {
        public static Func<IAmAQueue> ForHost =
            () => new Queue("DataPlatform.DataProviders.Host.Write", "DataPlatform.DataProviders.Host.Write",
                string.Empty, ExchangeType.Fanout, QueueFunction.WriteQueue, QueueType.Host);

        public static Func<IAmAQueue> ForAudit = () => new Queue("DataPlatform.DataProviders.Write.Audit",
            "DataPlatform.DataProviders.Write.Audit", string.Empty, ExchangeType.Fanout, QueueFunction.WriteQueue,
            QueueType.Audit);

        public static Func<IAmAQueue> ForErrors = () => new Queue("DataPlatform.DataProviders.Write.Error",
            "DataPlatform.DataProviders.Write.Error", string.Empty, ExchangeType.Fanout, QueueFunction.WriteQueue,
            QueueType.Error);

        public static Func<IAmAQueue> ForRetries =
            () => new Queue("DataPlatform.DataProviders.Host.Retries",
                "DataPlatform.DataProviders.Host.Retries", string.Empty, ExchangeType.Fanout, QueueFunction.WriteQueue,
                QueueType.Retries);
    }

    public class ConfigureDataProviderReadQueues
    {
        public static Func<IAmAQueue> ForHost =
            () => new Queue("DataPlatform.DataProviders.Host.Read",
                "DataPlatform.DataProviders.Host.Read", string.Empty, ExchangeType.Fanout,
                QueueFunction.ReadQueue, QueueType.Host);

        public static Func<IAmAQueue> ForAudit =
            () => new Queue("DataPlatform.DataProviders.Read.Audit", "DataPlatform.DataProviders.Read.Audit",
                string.Empty, ExchangeType.Fanout, QueueFunction.ReadQueue, QueueType.Audit);

        public static Func<IAmAQueue> ForErrors =
            () => new Queue("DataPlatform.DataProviders.Read.Error", "DataPlatform.DataProviders.Read.Error",
                string.Empty, ExchangeType.Fanout, QueueFunction.ReadQueue, QueueType.Error);

        public static Func<IAmAQueue> ForRetries =
            () => new Queue("DataPlatform.DataProviders.Host.Read.Retries",
                "DataPlatform.DataProviders.Host.Read.Retries", string.Empty, ExchangeType.Fanout,
                QueueFunction.ReadQueue, QueueType.Retries);
    }
    public class ConfigureDataProviderExchangesToBind
    {
        public static Func<IAmAnExchange> ForReadHost =
            () =>
                new Exchange("DataPlatform.Shared.Messaging:IPublishableMessage", ExchangeType.Fanout, string.Empty);
    }

    public class ConfigureDataProviderExchanges
    {
        public static Func<IEnumerable<IAmAnExchange>> ForEvents = () =>
        {
            //var type = typeof (Lace.Shared.Monitoring.Messages.Events.IDataProviderEvent);
            var type = typeof (DataPlatform.Shared.Messaging.IPublishableMessage);
            var exchanges = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(w => type.IsAssignableFrom(w) && w.IsClass)
                .Select(s => new Exchange(s.FullName, ExchangeType.Fanout, string.Empty));

            return exchanges;
        };
    }
}
