using System;

namespace Workflow.BuildingBlocks
{
    public class ConsumerRegistration
    {
        private readonly ConsumerRegistrationConstruction consumer;

        public ConsumerRegistration(Type messageType, ConsumerRegistrationConstruction consumer)
        {
            this.consumer = consumer;
            MessageType = messageType;
        }

        public Type MessageType { get; private set; }

        public Type ConsumerType
        {
            get { return consumer.ConsumerType; }
        }

        public object CreateConsumer()
        {
            return consumer.Create();
        }
    }
}