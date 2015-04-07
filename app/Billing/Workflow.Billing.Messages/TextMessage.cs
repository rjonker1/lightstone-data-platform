using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Messaging;

namespace Workflow.Billing.Messages
{
   
    public class TextMessage : IPublishableMessage
    {
        public TextMessage() { }

        public string Text { get; set; }
    }
}