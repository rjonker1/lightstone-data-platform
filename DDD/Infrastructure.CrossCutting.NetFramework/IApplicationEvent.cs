namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework
{
    public interface IApplicationEvent : IDomainEvent
    {
        string EventType { get; }
    }
}