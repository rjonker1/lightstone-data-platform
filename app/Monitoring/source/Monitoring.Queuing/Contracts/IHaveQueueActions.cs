namespace Monitoring.Queuing.Contracts
{
    public interface IHaveQueueActions
    {
        void ProcessQueue(string exchangeName, string queueName, string routingKey, string exchangeType);
        void AddAllQueues();
        void PurgeAllQueues();
        void DeleteAllQueues();
        int GetMessageCount(string exchangeName, string queueName, string routingKey, string exchangeType);
    }
}