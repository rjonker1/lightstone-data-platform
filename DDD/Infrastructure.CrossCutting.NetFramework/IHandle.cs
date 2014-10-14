namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework
{
    public interface IHandle<T> where T : IDomainEvent
    {
        void Handle(T args);
    }
}