using System;
using System.Threading.Tasks;
using EasyNetQ;
using EasyNetQ.Consumer;
using EasyNetQ.FluentConfiguration;

namespace Workflow.RabbitMQ.Tests.Fakes
{
    public class FailingBus : IBus
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int NumberOfTimesCalled { get; private set; }

        public void Publish<T>(T message) where T : class
        {
            NumberOfTimesCalled++;
            throw new Exception("I always fail");
        }

        public void Publish<T>(T message, string topic) where T : class
        {
            throw new Exception("I always fail");
        }

        public Task PublishAsync<T>(T message) where T : class
        {
            throw new NotImplementedException();
        }

        public Task PublishAsync<T>(T message, string topic) where T : class
        {
            throw new NotImplementedException();
        }

        public IDisposable Subscribe<T>(string subscriptionId, Action<T> onMessage) where T : class
        {
            throw new NotImplementedException();
        }

        public IDisposable Subscribe<T>(string subscriptionId, Action<T> onMessage, Action<ISubscriptionConfiguration> configure) where T : class
        {
            throw new NotImplementedException();
        }

        public IDisposable SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : class
        {
            throw new NotImplementedException();
        }

        public IDisposable SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage, Action<ISubscriptionConfiguration> configure) where T : class
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

        public IDisposable RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> responder) where TRequest : class where TResponse : class
        {
            throw new NotImplementedException();
        }

        public void Send<T>(string queue, T message) where T : class
        {
            throw new NotImplementedException();
        }

        public IDisposable Receive<T>(string queue, Action<T> onMessage) where T : class
        {
            throw new NotImplementedException();
        }

        public IDisposable Receive<T>(string queue, Func<T, Task> onMessage) where T : class
        {
            throw new NotImplementedException();
        }

        public IDisposable Receive(string queue, Action<IReceiveRegistration> addHandlers)
        {
            throw new NotImplementedException();
        }

        public bool IsConnected { get; private set; }
        public IAdvancedBus Advanced { get; private set; }
        public event Action Connected = () => { };
        public event Action Disconnected = () => { };
    }
}