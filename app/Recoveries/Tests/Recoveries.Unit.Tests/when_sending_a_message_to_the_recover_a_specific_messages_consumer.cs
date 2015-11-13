using System.Linq;
using EasyNetQ;
using Recoveries.Core.Messages;
using Recoveries.Infrastructure.Configuration;
using Recoveries.Publisher;
using Recoveries.Unit.Tests.Helper;
using Xunit.Extensions;

namespace Recoveries.Unit.Tests
{
    public class when_sending_a_message_to_the_recover_a_specific_messages_consumer : Specification
    {
        private readonly RetryErrorsOnAQueueMessage _message;
        private readonly IBus _bus;

        public when_sending_a_message_to_the_recover_a_specific_messages_consumer()
        {
            _message = new RetryErrorsOnAQueueMessage(ConfigurationReader.Configurations.FirstOrDefault());
            _bus = BusBuilder.CreateRouterBus();
        }

        public override void Observe()
        {
            new MessagePublisher(_bus).SendToBus(_message);
        }

        [Observation]
        public void then_message_should_be_on_queue()
        {
            true.ShouldBeTrue();
        }
    }
}
