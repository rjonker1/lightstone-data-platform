namespace Recoveries.ErrorQueues
{
    public interface IErrorQueueConfiguration
    {
        IQueueOptions Options { get; }
    }
}
