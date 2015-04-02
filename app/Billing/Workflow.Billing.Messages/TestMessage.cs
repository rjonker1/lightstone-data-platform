using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Messaging;

namespace Workflow.Billing.Messages
{
    [Serializable]
    [DataContract]
    public class TestMessage : IPublishableMessage
    {
        public TestMessage()
        {
        }
    }
}