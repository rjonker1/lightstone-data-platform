using System;

namespace Workflow.BuildingBlocks
{
    public class ConsumerRegistrationConstruction
    {
        private readonly Func<object> creation;
        public Type ConsumerType { get; private set; }

        public ConsumerRegistrationConstruction(Type consumerType, Func<object> creation)
        {
            this.creation = creation;
            ConsumerType = consumerType;
        }

        public object Create()
        {
            return creation();
        }
    }
}