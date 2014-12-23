namespace Monitoring.Queuing.Contracts
{
    public interface IHaveQueueActions
    {
        void AddAllQueues();
        void PurgeAllQueues();
        void DeleteAllQueues();
    }
}