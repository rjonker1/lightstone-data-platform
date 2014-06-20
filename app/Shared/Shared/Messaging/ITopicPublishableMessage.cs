namespace DataPlatform.Shared.Messaging
{
    public interface ITopicPublishableMessage : IPublishableMessage
    {
        MessageTopic Topic { get; }
    }
}