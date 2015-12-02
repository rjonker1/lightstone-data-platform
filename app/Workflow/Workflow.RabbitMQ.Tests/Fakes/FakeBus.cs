using System;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.Consumer;
using EasyNetQ.FluentConfiguration;
using EasyNetQ.Producer;

namespace Workflow.RabbitMQ.Tests.Fakes
{
    public class FakeBus : IBus
    {
        public bool PublishWasCalled { get; private set; }

        public object PublishedMessage { get; private set; }

        public void Dispose()
        {
        }

        public void Publish<T>(T message) where T : class
        {
            PublishWasCalled = true;
            PublishedMessage = message;
        }

        public void Publish<T>(T message, string topic) where T : class
        {
            TopicPublishedWasCalled = true;
            PublishedMessage = message;
        }

        public Task PublishAsync<T>(T message) where T : class
        {
            throw new NotImplementedException();
        }

        public Task PublishAsync<T>(T message, string topic) where T : class
        {
            throw new NotImplementedException();
        }

        public ISubscriptionResult Subscribe<T>(string subscriptionId, Action<T> onMessage) where T : class
        {
            throw new NotImplementedException();
        }

        public ISubscriptionResult Subscribe<T>(string subscriptionId, Action<T> onMessage, Action<ISubscriptionConfiguration> configure) where T : class
        {
            throw new NotImplementedException();
        }

        public ISubscriptionResult SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : class
        {
            throw new NotImplementedException();
        }

        public ISubscriptionResult SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage, Action<ISubscriptionConfiguration> configure) where T : class
        {
            throw new NotImplementedException();
        }

        public TResponse Request<TRequest, TResponse>(TRequest request) where TRequest : class where TResponse : class
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request) where TRequest : class where TResponse : class
        {
            throw new NotImplementedException();
        }

        public IDisposable Respond<TRequest, TResponse>(Func<TRequest, TResponse> responder) where TRequest : class where TResponse : class
        {
            throw new NotImplementedException();
        }

        public IDisposable Respond<TRequest, TResponse>(Func<TRequest, TResponse> responder, Action<IResponderConfiguration> configure) where TRequest : class where TResponse : class
        {
            throw new NotImplementedException();
        }

        public IDisposable RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> responder) where TRequest : class where TResponse : class
        {
            throw new NotImplementedException();
        }

        public IDisposable RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> responder, Action<IResponderConfiguration> configure) where TRequest : class where TResponse : class
        {
            throw new NotImplementedException();
        }

        public void Send<T>(string queue, T message) where T : class
        {
            throw new NotImplementedException();
        }

        public Task SendAsync<T>(string queue, T message) where T : class
        {
            throw new NotImplementedException();
        }

        public IDisposable Receive<T>(string queue, Action<T> onMessage) where T : class
        {
            throw new NotImplementedException();
        }

        public IDisposable Receive<T>(string queue, Action<T> onMessage, Action<IConsumerConfiguration> configure) where T : class
        {
            throw new NotImplementedException();
        }

        public IDisposable Receive<T>(string queue, Func<T, Task> onMessage) where T : class
        {
            throw new NotImplementedException();
        }

        public IDisposable Receive<T>(string queue, Func<T, Task> onMessage, Action<IConsumerConfiguration> configure) where T : class
        {
            throw new NotImplementedException();
        }

        public IDisposable Receive(string queue, Action<IReceiveRegistration> addHandlers)
        {
            throw new NotImplementedException();
        }

        public IDisposable Receive(string queue, Action<IReceiveRegistration> addHandlers, Action<IConsumerConfiguration> configure)
        {
            throw new NotImplementedException();
        }

        public bool IsConnected { get; private set; }
        public IAdvancedBus Advanced { get; private set; }
        public bool TopicPublishedWasCalled { get; private set; }

        public event Action Connected = () => { };
        public event Action Disconnected = () => { };
    }
}