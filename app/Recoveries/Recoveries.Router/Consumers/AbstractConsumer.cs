namespace Recoveries.Router.Consumers
{

    public interface IConsumeMessages
    {
        void Consume(object message);
    }

    public interface IConsumeMessages<in TMessage> : IConsumeMessages where TMessage : class
    {
        void Consume(TMessage message);
    }

    public abstract class AbstractConsumer<TMessage> : IConsumeMessages<TMessage> where TMessage : class
    {
        public abstract void Consume(TMessage message);

        public void Consume(object message)
        {
            var actualMessage = message as TMessage;
            Consume(actualMessage);
        }
    }
}
