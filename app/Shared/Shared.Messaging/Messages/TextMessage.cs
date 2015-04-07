
namespace DataPlatform.Shared.Messaging.Messages
{
    public class TextMessage : IPublishableMessage
    {
        public TextMessage() { }

        public string Text { get; set; }
    }
}