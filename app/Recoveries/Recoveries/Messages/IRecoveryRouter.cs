using System;
namespace Recoveries.Messages
{
    public interface IRecoveryRouter : IDisposable
    {
        void Publish(IRecoverRoutingMessage message);
        void Subscribe<TMessage>(Action<IRecoverRoutingMessage> dispatch);
    }
}
