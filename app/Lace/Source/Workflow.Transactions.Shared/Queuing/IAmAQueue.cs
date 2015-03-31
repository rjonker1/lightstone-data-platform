namespace Workflow.Transactions.Shared.Queuing
{
    public interface IAmAQueue
    {
        string QueueName { get; }
        string ExchangeName { get; }
        string RoutingKey { get; }
        string ExchangeType { get; }
        QueueFunction QueueFunction { get; }
        QueueType QueueType { get; }
    }

    public enum QueueFunction
    {
        ReadQueue,
        WriteQueue
    }

    public enum QueueType
    {
        Host,
        Audit,
        Error,
        Retries
    }
}
