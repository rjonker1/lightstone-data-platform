namespace Workflow.Transactions.Shared.Queuing
{
    public interface IInitializeQueues
    {
        bool QueuesInitialized { get; }
        void InitializeAllQueues();
        void InitializeAllExchanges();
        void InitializeReadQueues();
        void InitializeWriteQueues();
    }
}
