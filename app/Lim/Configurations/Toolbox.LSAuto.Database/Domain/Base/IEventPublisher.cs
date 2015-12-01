namespace Toolbox.LightstoneAuto.Database.Domain.Base
{
    public interface IEventPublisher
    {
        void Publish<T>(T @event) where T : Event;
    }
}
