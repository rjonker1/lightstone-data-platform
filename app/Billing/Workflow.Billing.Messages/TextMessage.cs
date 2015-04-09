using DataPlatform.Shared.Messaging;
using Workflow.Billing.Messages.EntitiesBuilder;

namespace Workflow.Billing.Messages
{
   
    public class TextMessage : Entity, IPublishableMessage
    {
        public string Text { get; set; }
    }
}