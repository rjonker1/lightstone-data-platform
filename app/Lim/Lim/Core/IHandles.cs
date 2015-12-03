namespace Lim.Core
{
    public interface IHandles<in T>
    {
        void Handle(T message);
    }
}
