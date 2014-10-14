namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework
{
    public interface IMessagePublisher
    {
        void Publish(IApplicationEvent applicationEvent);
    }
}