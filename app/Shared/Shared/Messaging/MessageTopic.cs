namespace DataPlatform.Shared.Messaging
{
    public class MessageTopic
    {
        public string Topic { get; private set; }

        public MessageTopic(string topic)
        {
            Topic = topic;
        }
    }
}