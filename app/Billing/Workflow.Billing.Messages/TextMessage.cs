using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Messaging;

namespace Workflow.Billing.Messages
{
    [Serializable]
    [DataContract]
    public class TextMessage : IPublishableMessage
    {
        public TextMessage() { }

        [DataMember]
        public string Text { get; set; }
    }
}