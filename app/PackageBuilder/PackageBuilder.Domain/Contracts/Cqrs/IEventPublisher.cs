using PackageBuilder.Domain.Events;

namespace PackageBuilder.Domain.Contracts.Cqrs
{
    public interface IEventPublisher
    {
        void Publish<T>(T @event) where T : Event;
    }
}