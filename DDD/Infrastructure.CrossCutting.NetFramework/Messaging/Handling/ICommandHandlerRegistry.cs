namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.Messaging.Handling
{
    public interface ICommandHandlerRegistry
    {
        void Register(ICommandHandler handler);
    }
}
