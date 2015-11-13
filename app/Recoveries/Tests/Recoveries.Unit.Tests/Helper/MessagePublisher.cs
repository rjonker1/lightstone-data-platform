using EasyNetQ;

namespace Recoveries.Unit.Tests.Helper
{
    public sealed class MessagePublisher
    {
        private readonly IBus _bus;

        public MessagePublisher(IBus bus)
        {
            _bus = bus;
        }

        public void SendToBus<T>(T message) where T : class
        {
            _bus.Publish(message);
        }
    }
}
