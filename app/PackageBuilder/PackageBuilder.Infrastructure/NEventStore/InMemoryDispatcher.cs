using System.Linq;
using DataPlatform.Shared.Helpers.Extensions;
using MemBus;
using NEventStore;
using NEventStore.Dispatcher;
using PackageBuilder.Core.Events;

namespace PackageBuilder.Infrastructure.NEventStore
{
    public class InMemoryDispatcher : IDispatchCommits
    {
        private readonly IBus _bus;

        public InMemoryDispatcher(IBus bus)
        {
            _bus = bus;
        }

        public void Dispose()
        {
            _bus.Dispose();
        }

        public void Dispatch(ICommit commit)
        {
            foreach (var @event in commit.Events.Where(x => x.Body is IDomainEvent))
            {
                var tmp = @event;

                this.Info(() => string.Format("Attempting to dispatch event: {0}", tmp));

                _bus.Publish(@event.Body);

                this.Info(() => string.Format("Successfully dispatched event: {0}", tmp));                
            }
        }
    }
}