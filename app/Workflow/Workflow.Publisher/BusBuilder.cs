using System;
using EasyNetQ;
using Workflow.Publisher.Configurations;
using Workflow.Publisher.Loggers;

namespace Workflow.Publisher
{
    public class BusBuilder
    {
        public static IBus CreateBus()
        {
            return CreateMessageBus(ConfigurationReader.Bus);
        }

        public static IBus CreateMessageBus(IDefineBusEnvironment busEnvironment)
        {
            var connectionString = busEnvironment.Host;

            IConventions conventions = new Conventions(new TypeNameSerializer())
            {
                ExchangeNamingConvention = type => ExchangeNamedBasedOnEnvironment(busEnvironment),
                QueueNamingConvention = (type, info) => QueueNameBasedOnAttribute(type),
                TopicNamingConvention = type => type.Name,
                ErrorExchangeNamingConvention = info => ErrorExchangeNameBasedOnEnvironment(busEnvironment),
                ErrorQueueNamingConvention = () => ErrorQueueNameBasedOnEnvironment(busEnvironment)
            };

            var bus = RabbitHutch.CreateBus(connectionString, x =>
            {
                x.Register(provider => conventions);
                x.Register<IEasyNetQLogger, WorkflowLogger>();
            });
            return bus;
        }

        private static string ErrorQueueNameBasedOnEnvironment(IDefineBusEnvironment busEnvironment)
        {
            return busEnvironment.ErrorQueueName.ToLowerInvariant();
        }

        private static string ErrorExchangeNameBasedOnEnvironment(IDefineBusEnvironment busEnvironment)
        {
            return busEnvironment.ErrorExchangeName.ToLowerInvariant();
        }

        private static string ExchangeNamedBasedOnEnvironment(IDefineBusEnvironment busEnvironment)
        {
            return busEnvironment.ExchangeName.ToLowerInvariant();
        }

        private static string QueueNameBasedOnAttribute(Type messageType)
        {
            var queueName = messageType.Name;

            return string.Format("{0}", ConfigurationReader.Environment.AppendEnvironment(queueName.ToLowerInvariant()));
        }
    }
}