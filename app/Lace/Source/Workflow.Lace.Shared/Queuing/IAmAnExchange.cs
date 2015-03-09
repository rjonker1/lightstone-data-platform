namespace Workflow.Lace.Shared.Queuing
{
    public interface IAmAnExchange
    {
        string ExchangeName { get; }
        string ExchangeType { get; }
        string RoutingKey { get; }
    }
}
