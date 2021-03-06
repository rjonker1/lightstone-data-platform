using System;
using DataPlatform.Shared.Messaging;

namespace Workflow.RabbitMQ.Publishers
{
    internal interface IRabbitMQPublisher : IDisposable
    {
        void Publish<TMessage>(TMessage message) where TMessage : class, IPublishableMessage;
        bool CanPublishMessage<TMessage>(TMessage message) where TMessage : class, IPublishableMessage;
    }
}