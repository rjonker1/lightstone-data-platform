namespace Toolbox.Emailing.Domain
{
    public interface IDispatchMail
    {
        void Send(object message);
    }

    public interface IDispatchMail<in T> : IDispatchMail
    {
        void Send(T message);
    }
}
