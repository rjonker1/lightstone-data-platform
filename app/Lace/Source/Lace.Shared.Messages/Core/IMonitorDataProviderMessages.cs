namespace Lace.Shared.Monitoring.Messages.Core
{
    internal interface IMonitorDataProviderMessages
    {
        void SendToBus<T>(T message) where T : class;
    }
}
