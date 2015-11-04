using EasyNetQ;
using Recoveries.Core;
using Recoveries.Infrastructure.Configuration.Queues;

namespace Recoveries.Publisher
{
    public class BusBuilder
    {
        public static IBus CreateRouterBus()
        {
            return CreateBus(RecoveryReceiverQueueConfiguration.Receiver());
        }

        public static IBus CreateBus(IDefineRabbitQueue queue)
        {
            var connectionString = queue.Host;
            IConventions conventions = new Conventions(new TypeNameSerializer())
            {
                ExchangeNamingConvention = type => queue.ExchangeName,
                QueueNamingConvention = (type, info) => queue.QueueName,
                TopicNamingConvention = type => type.Name,
                ErrorExchangeNamingConvention = info => ErrorExchangeNameBasedOnEnvironment(queue),
                ErrorQueueNamingConvention = () => ErrorQueueNameBasedOnEnvironment(queue)
            };

            var bus = RabbitHutch.CreateBus(connectionString, x =>
            {
                x.Register(provider => conventions);
            });
            return bus;
        }

        private static string ErrorQueueNameBasedOnEnvironment(IDefineRabbitQueue queue)
        {
            return queue.ErrorQueueName.ToLowerInvariant();
        }

        private static string ErrorExchangeNameBasedOnEnvironment(IDefineRabbitQueue queue)
        {
            return queue.ErrorExchangeName.ToLowerInvariant();
        }
    }
}