using Recoveries.Core.Messages;

namespace Recoveries.Domain.Base
{
    public interface IConsumeMessages
    {
        void Consume(object message);
    }

    public interface IConsumeMessages<in TMessage> : IConsumeMessages where TMessage : class, IRecoverMessage
    {
        void Consume(TMessage message);
    }

    public abstract class AbstractConsumer<TMessage> : IConsumeMessages<TMessage> where TMessage : class,IRecoverMessage
    {
        public abstract void Consume(TMessage message);

        public void Consume(object message)
        {
            var actualMessage = message as TMessage;
            Consume(actualMessage);
        }
    }
}
