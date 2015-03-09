namespace Workflow.Lace.Shared.Queuing
{
    interface IHaveQueueActions
    {
        void ProcessQueue(string exchangeName, string queueName, string routingKey, string exchangeType);
        void AddAllQueues();
        void PurgeAllQueues();
        void DeleteAllQueues();
        void DeleteAllExchanges();
        void AddAllExchanges();
        int GetMessageCount(string exchangeName, string queueName, string routingKey, string exchangeType);
    }
}
