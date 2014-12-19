namespace Monitoring.RabbitMq
{
    public interface ISetupQueues
    {
        void AddQueues();
        void DeleteAllQueues();
    }
}