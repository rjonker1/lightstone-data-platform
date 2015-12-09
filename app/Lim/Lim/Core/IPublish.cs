namespace Lim.Core
{
    public interface IPublish
    {
        void Publish<T>(T @event) where T : IMessage;
    }
}
