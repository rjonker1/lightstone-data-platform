namespace Workflow.BuildingBlocks
{
    public interface IDefineQueue
    {
        string ConnectionStringKey { get; }
        //string QueueName { get; }
        //string ExchangeName { get; }
        string ErrorExchangeName { get; }
        string ErrorQueueName { get; }
        string ExchangeType { get; }
    }
}
