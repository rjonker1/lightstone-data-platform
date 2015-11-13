namespace Recoveries.Core
{
    public interface IDefineRabbitQueue
    {
        string Host { get; }
        string ExchangeName { get; }
        string ErrorExchangeName { get; }
        string ErrorQueueName { get; }
        string QueueName { get; }
    }
}
