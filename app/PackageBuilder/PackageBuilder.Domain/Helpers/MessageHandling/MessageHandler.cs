namespace PackageBuilder.Domain.Helpers.MessageHandling
{
    public interface IHandleMessages<T> : IHandleMessages
    {
        void Handle(T command);
    }

    public abstract class MessageHandler<T> : IHandleMessages<T>
    {
        public abstract void Handle(T command);

        public void Handle(object command)
        {
            Handle((T)command);
        }
    }
}