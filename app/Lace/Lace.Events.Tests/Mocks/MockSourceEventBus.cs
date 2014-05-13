using System;
using System.Threading.Tasks;
using EasyNetQ;

namespace Lace.Events.Tests.Mocks
{
    public class MockSourceEventBus : IBus
    {
        public IAdvancedBus Advanced
        {
            get { throw new NotImplementedException(); }
        }

        public event Action Connected;

        public event Action Disconnected;

        public bool IsConnected
        {
            get { throw new NotImplementedException(); }
        }

        public void Publish<T>(T message, string topic) where T : class
        {
            
        }

        public void Publish<T>(T message) where T : class
        {
           
        }

        public Task PublishAsync<T>(T message, string topic) where T : class
        {
            throw new NotImplementedException();
        }

        public Task PublishAsync<T>(T message) where T : class
        {
            throw new NotImplementedException();
        }

        public IDisposable Receive(string queue, Action<EasyNetQ.Consumer.IReceiveRegistration> addHandlers)
        {
            throw new NotImplementedException();
        }

        public IDisposable Receive<T>(string queue, Func<T, Task> onMessage) where T : class
        {
            throw new NotImplementedException();
        }

        public IDisposable Receive<T>(string queue, Action<T> onMessage) where T : class
        {
            throw new NotImplementedException();
        }

        public TResponse Request<TRequest, TResponse>(TRequest request)
            where TRequest : class
            where TResponse : class
        {
            throw new NotImplementedException();
        }

        public Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest : class
            where TResponse : class
        {
            throw new NotImplementedException();
        }

        public IDisposable Respond<TRequest, TResponse>(Func<TRequest, TResponse> responder)
            where TRequest : class
            where TResponse : class
        {
            throw new NotImplementedException();
        }

        public IDisposable RespondAsync<TRequest, TResponse>(Func<TRequest, Task<TResponse>> responder)
            where TRequest : class
            where TResponse : class
        {
            throw new NotImplementedException();
        }

        public void Send<T>(string queue, T message) where T : class
        {
            throw new NotImplementedException();
        }

        public IDisposable Subscribe<T>(string subscriptionId, Action<T> onMessage, Action<EasyNetQ.FluentConfiguration.ISubscriptionConfiguration> configure) where T : class
        {
            throw new NotImplementedException();
        }

        public IDisposable Subscribe<T>(string subscriptionId, Action<T> onMessage) where T : class
        {
            throw new NotImplementedException();
        }

        public IDisposable SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage, Action<EasyNetQ.FluentConfiguration.ISubscriptionConfiguration> configure) where T : class
        {
            throw new NotImplementedException();
        }

        public IDisposable SubscribeAsync<T>(string subscriptionId, Func<T, Task> onMessage) where T : class
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
