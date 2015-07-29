namespace Recoveries.Router.Consumers
{
    public interface IConsumeMessage
    {
        void Consume(object message);
    }

    public interface IConsumeMessage<in TMessage> : IConsumeMessage where TMessage : class
    {
        void Consume(TMessage message);
    }

    public abstract class AbstractConsumer<TMessage> : IConsumeMessage<TMessage> where TMessage : class
    {
        public abstract void Consume(TMessage message);

        public void Consume(object message)
        {
            var actualMessage = message as TMessage;
            Consume(actualMessage);
        }
    }
}
