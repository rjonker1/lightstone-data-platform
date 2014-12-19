using System;
using Monitoring.RabbitMq;
using Xunit.Extensions;

namespace Monitoring.Acceptance.Tests.Queues
{
    public class when_creating_queues_on_rabbit_mq : Specification
    {
        private readonly QueueSetup _setup;
        private readonly IConsumeMessagesFromQueue _consumer;

        public when_creating_queues_on_rabbit_mq()
        {
            _consumer = new Consumer("localhost", "admin", "changeit");
            _setup = new QueueSetup(_consumer);
        }

        public override void Observe()
        {
           _setup.DeleteAllQueues();
           _setup.AddQueues();
        }

        [Observation]
        public void then_queues_should_exist()
        {
            
        }
    }
}
