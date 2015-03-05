namespace Workflow.Lace.Shared.Queuing
{
    public interface IBindToAQueue
    {
        IAmAQueue Queue { get; }
        string QueueName { get; }
        string ExchangeName { get; }
        string RoutingKey { get; }
    }
}
