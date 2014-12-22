namespace Monitoring.Queuing.Contracts
{
    public interface IInitializeQueues
    {
        bool QueuesInitialized { get; }
        void InitializeAllQueues();
        void InitializeReadQueues();
        void InitializeWriteQueues();
    }
}
