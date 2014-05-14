using EasyNetQ;

namespace Lace.Tests.Data.Fakes
{
    public class FakeBus : IBus
    {
        public IAdvancedBus Advanced
        {
            get { throw new System.NotImplementedException(); }
        }

        public event System.Action Connected;

        public event System.Action Disconnected;

        public bool IsConnected
        {
            get { throw new System.NotImplementedException(); }
        }

        public void Publish<T>(T message, string topic) where T : class
        {
           
        }

        public void Publish<T>(T message) where T : class
        {
           
        }

        public System.Threading.Tasks.Task PublishAsync<T>(T message, string topic) where T : class
        {
            throw new System.NotImplementedException();
        }

        public System.Threading.Tasks.Task PublishAsync<T>(T message) where T : class
        {
            throw new System.NotImplementedException();
        }

        public System.IDisposable Receive(string queue, System.Action<EasyNetQ.Consumer.IReceiveRegistration> addHandlers)
        {
            throw new System.NotImplementedException();
        }

        public System.IDisposable Receive<T>(string queue, System.Func<T, System.Threading.Tasks.Task> onMessage) where T : class
        {
            throw new System.NotImplementedException();
        }

        public System.IDisposable Receive<T>(string queue, System.Action<T> onMessage) where T : class
        {
            throw new System.NotImplementedException();
        }

        public TResponse Request<TRequest, TResponse>(TRequest request)
            where TRequest : class
            where TResponse : class
        {
            throw new System.NotImplementedException();
        }

        public System.Threading.Tasks.Task<TResponse> RequestAsync<TRequest, TResponse>(TRequest request)
            where TRequest : class
            where TResponse : class
        {
            throw new System.NotImplementedException();
        }

        public System.IDisposable Respond<TRequest, TResponse>(System.Func<TRequest, TResponse> responder)
            where TRequest : class
            where TResponse : class
        {
            throw new System.NotImplementedException();
        }

        public System.IDisposable RespondAsync<TRequest, TResponse>(System.Func<TRequest, System.Threading.Tasks.Task<TResponse>> responder)
            where TRequest : class
            where TResponse : class
        {
            throw new System.NotImplementedException();
        }

        public void Send<T>(string queue, T message) where T : class
        {
            throw new System.NotImplementedException();
        }

        public System.IDisposable Subscribe<T>(string subscriptionId, System.Action<T> onMessage, System.Action<EasyNetQ.FluentConfiguration.ISubscriptionConfiguration> configure) where T : class
        {
            throw new System.NotImplementedException();
        }

        public System.IDisposable Subscribe<T>(string subscriptionId, System.Action<T> onMessage) where T : class
        {
            throw new System.NotImplementedException();
        }

        public System.IDisposable SubscribeAsync<T>(string subscriptionId, System.Func<T, System.Threading.Tasks.Task> onMessage, System.Action<EasyNetQ.FluentConfiguration.ISubscriptionConfiguration> configure) where T : class
        {
            throw new System.NotImplementedException();
        }

        public System.IDisposable SubscribeAsync<T>(string subscriptionId, System.Func<T, System.Threading.Tasks.Task> onMessage) where T : class
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
