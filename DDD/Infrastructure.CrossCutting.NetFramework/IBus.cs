namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework
{
    public interface IBus
    {
        void Publish(IDomainEvent @event);
    }
}