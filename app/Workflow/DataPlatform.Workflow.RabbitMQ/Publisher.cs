using System;
using Common.Logging;
using DataPlatform.BuildingBlocks.Recovery;
using DataPlatform.Shared.Public.Messaging;
using DataPlatform.Workflow.RabbitMQ.Publishers;
using EasyNetQ;

namespace DataPlatform.Workflow.RabbitMQ
{
    public class Publisher : IPublishMessages
    {
        private static readonly ILog log = LogManager.GetLogger<Publisher>();
        private readonly RetryAgent agent;
        private readonly IRabbitMQPublisher publisher;

        public Publisher(IBus bus, IRetryStrategy retryStrategy)
        {
            publisher = new TopicBasedPublisher(bus, new DefaultPublisher(bus));
            agent = new RetryAgent(retryStrategy);
        }

        public Publisher(IBus bus) : this(bus, new DefaultRabbitMQRetryStrategy())
        {
        }

        public void Publish(IPublishableMessage message)
        {
            if (message == null)
            {
                log.WarnFormat("Received a NULL message. Can't publish a NULL message");
                throw new ArgumentNullException("message");
            }

            log.InfoFormat("Publishing {0} in RabbitMQ publisher", message.GetType());

            PublishWithRetry(message);
        }

        private void PublishWithRetry(IPublishableMessage message)
        {
            var results = agent
                .OnException(e => log.ErrorFormat("Failed to publish message {0} to RabbitMQ, because '{1}'", message.GetType(), e))
                .Execute(() => publisher.Publish(message), () => true);

            if (!results.Succeeded)
                throw results.FirstFailure();
        }
    }
}