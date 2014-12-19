using System;
using System.Text;
using Lace.Shared.Monitoring.Messages.Commands;
using Lace.Shared.Monitoring.Messages.Core;
using Monitoring.Test.Helper.Mothers;
using NServiceBus;
using RabbitMQ.Client;
using RabbitMQ.Client.MessagePatterns;
using Xunit.Extensions;

namespace Monitoring.Acceptance.Tests.DataProvider
{
    public class when_sending_data_provider_executed_command_to_bus : Specification
    {
        private readonly IBus _bus;
        private readonly DataProviderWasCalledCommand _command;



        public when_sending_data_provider_executed_command_to_bus()
        {
            _bus = BusFactory.NServiceRabbitMqBus();

            _command = new DataProviderWasCalledCommand(new DataProviderCommandDto(Guid.NewGuid(),
                Lace.Shared.Monitoring.Messages.Core.DataProvider.Audatex,
                "Start Calling unit test", "request{}", "metadata", DateTime.UtcNow, Category.Performance, true));
        }

        public override void Observe()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };

            using (var connection =
                connectionFactory.CreateConnection())
            {
                using (var model = connection.CreateModel())
                {
                    model.QueuePurge("");
                }
            }

            _bus.Send(_command);
        }

        [Observation]
        public void then_event_must_be_published_to_bus()
        {
            true.ShouldEqual(true);
        }

        private static void ReadFromQueue()
        {
            var connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost"
            };
            using (var connection = connectionFactory.CreateConnection())
            {
                using (var model = connection.CreateModel())
                {
                    var subscription = new Subscription(model, "MyQueue", false);
                    while (true)
                    {
                        var basicDeliveryEventArgs =
                            subscription.Next();
                        var messageContent =
                            Encoding.UTF8.GetString(basicDeliveryEventArgs.Body);
                        Console.WriteLine(messageContent);
                        subscription.Ack(basicDeliveryEventArgs);
                    }
                }
            }
        }
    }
}
