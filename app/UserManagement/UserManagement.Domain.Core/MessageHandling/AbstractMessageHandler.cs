namespace UserManagement.Domain.Core.MessageHandling
{
    public interface IHandleMessages<T> : IHandleMessages
    {
        void Handle(T command);
    }

    public abstract class AbstractMessageHandler<T> : IHandleMessages<T>
    {
        public abstract void Handle(T command);

        public void Handle(object command)
        {
            Handle((T)command);
        }
    }
}