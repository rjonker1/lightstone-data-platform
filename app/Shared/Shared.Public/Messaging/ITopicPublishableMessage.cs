namespace DataPlatform.Shared.Public.Messaging
{
    public interface ITopicPublishableMessage : IPublishableMessage
    {
        MessageTopic Topic { get; }
    }
}