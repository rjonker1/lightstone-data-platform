using System;
using Common.Logging;
using DataPlatform.Shared.Public.Messaging;
using DataPlatform.Workflow.RabbitMQ.Publishers;
using EasyNetQ;

namespace DataPlatform.Workflow.RabbitMQ
{
    public class Publisher : IPublishMessages
    {
        private readonly IRabbitMQPublisher publisher;
        private static readonly ILog log = LogManager.GetLogger<Publisher>();

        public Publisher(IBus bus)
        {
            publisher = new TopicBasedPublisher(bus, new DefaultPublisher(bus));
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
            var counter = 0;
            var success = false;

            while(counter <= 1 && !success)
            {
                try
                {
                    publisher.Publish(message);
                }
                catch (Exception e)
                {
                    if (counter >= 1)
                    {
                        throw;
                    }
                    success = false;
                }
                counter++;
            }
        }
    }
}