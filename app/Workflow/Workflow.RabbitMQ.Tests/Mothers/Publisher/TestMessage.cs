﻿using DataPlatform.Shared.Messaging;

namespace Workflow.RabbitMQ.Tests.Mothers.Publisher
{
    public class TestMessage : IPublishableMessage
    {
    }

    public class TopicTestMessage : ITopicPublishableMessage
    {
        public TopicTestMessage()
        {
            Topic = new MessageTopic("test/test/test");
        }

        public MessageTopic Topic { get; private set; }
    }
}