namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.Messaging.Handling
{
    public interface IEventHandlerRegistry
    {
        void Register(IEventHandler handler);
    }
}
