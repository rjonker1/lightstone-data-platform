
using DataPlatform.Shared.Messaging;

namespace Shared.Messaging.Billing.Messages
{
    public class TextMessage : IPublishableMessage
    {
        public TextMessage() { }

        public string Text { get; set; }
    }
}