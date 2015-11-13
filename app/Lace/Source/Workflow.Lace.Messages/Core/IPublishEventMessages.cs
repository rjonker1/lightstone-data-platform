namespace Workflow.Lace.Messages.Core
{
    public interface IPublishEventMessages
    {
        void SendToBus<T>(T message) where T : class;
    }
}
