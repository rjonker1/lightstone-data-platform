namespace Toolbox.LightstoneAuto.Database.Domain.Base
{
    public interface IHandles<in T>
    {
        void Handle(T message);
    }
}
