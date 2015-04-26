namespace Workflow.Lace.Messages.Core
{
    public interface IPublishBillingMessages
    {
        void SendToBus<T>(T message) where T : class;
    }
}
