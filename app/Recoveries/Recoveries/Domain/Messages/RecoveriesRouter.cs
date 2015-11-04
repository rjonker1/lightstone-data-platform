using System;
using EasyNetQ;
using Recoveries.Core.Messages;

namespace Recoveries.Domain.Messages
{
    public interface IRecoveriesRouter
    {
        void Publish(IRecoverMessage message);
        void Subscribe<TMessage>(Action<IRecoverMessage> dispatch);
    }

    public class RecoveriesRouter : IRecoveriesRouter
    {
        private readonly IBus _bus;

        public RecoveriesRouter(IBus bus)
        {
            _bus = bus;
        }

        public void Publish(IRecoverMessage message)
        {
            _bus.Publish(message);
        }

        public void Subscribe<TMessage>(Action<IRecoverMessage> dispatch)
        {
            _bus.Subscribe("Router", dispatch);
        }
    }
}
