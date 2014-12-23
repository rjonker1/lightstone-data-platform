using Monitoring.Queuing.Contracts;
using Monitoring.Queuing.RabbitMq;

namespace Monitoring.Test.Helper.Messages
{
    public class RabbitMqMessageQueueing
    {
        private readonly IHaveQueueActions _queueActions;
        private readonly IInitializeQueues _queueInitialization;
        public readonly IConsumeQueue Consumer;

        public RabbitMqMessageQueueing()
        {
            Consumer = new RabbitConsumer("localhost", "admin", "changeit");
            _queueActions = new QueueActions(Consumer);
            _queueInitialization = new QueueInitialization(Consumer);
        }

        public void DeleteQueues()
        {
            _queueActions.DeleteAllQueues();
        }

        public void AddQueues()
        {
            _queueActions.AddAllQueues();
        }

        public void PurgeQueues()
        {
            _queueActions.PurgeAllQueues();
        }

        public void InitializeReadQueues()
        {
            _queueInitialization.InitializeReadQueues();
        }

        public void InitializeWriteQueues()
        {
            _queueInitialization.InitializeWriteQueues();
        }
    }
}
