namespace Monitoring.Dashboard.UI.Core.Contracts.Services
{
    public interface IPublishCacheMessages
    {
        void SendToBus<T>(T message) where T : class;
    }
}
