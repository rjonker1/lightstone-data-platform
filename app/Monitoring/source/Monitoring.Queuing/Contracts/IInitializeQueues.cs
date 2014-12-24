namespace Monitoring.Queuing.Contracts
{
    public interface IInitializeQueues
    {
        bool QueuesInitialized { get; }
        void InitializeAllQueues();
        void InitializeAllExchanges();
        void InitializeReadQueues();
       // void InitializeReadExchanges();
        void InitializeWriteQueues();
        //void InitializeWriteExchanges();
    }
}
