namespace Workflow.BuildingBlocks.Configurations
{
    public interface IDefineBusEnvironment
    {
        string Host { get; }
        string ExchangeName { get; }
        string ErrorExchangeName { get; }
        string ErrorQueueName { get; }
    }
}