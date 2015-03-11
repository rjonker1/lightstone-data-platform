namespace Workflow.Lace.Messages.Core
{
    public interface IPublishCommandMessages
    {
        void SendToBus<T>(T message) where T : class;
    }
}
