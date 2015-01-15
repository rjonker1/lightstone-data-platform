namespace Lace.Shared.Monitoring.Messages.Core
{
    internal interface IPublishCommandMessages
    {
        void SendToBus<T>(T message) where T : class;
    }
}
