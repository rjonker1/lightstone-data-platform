using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using LightstoneApp.Infrastructure.Data.Core.Commits;
using Raven.Client;
using Topics.Radical.Validation;

namespace LightstoneApp.Infrastructure.Data.Core.Runtime
{
    internal class CommitDispatchConsumer : AbstractDispatchConsumer<Commit>
    {
        private readonly IOperationContextManager _contextManager;
        private readonly IDocumentStore _store;
        private readonly IBus bus;

        //public CommitDispatchConsumer( IBus bus, IDocumentStore store, IOperationContextManager contextManager )
        //{
        //    Ensure.That( bus ).Named( () => bus ).IsNotNull();
        //    Ensure.That( store ).Named( () => store ).IsNotNull();
        //    Ensure.That( contextManager ).Named( () => contextManager ).IsNotNull();

        //    this.bus = bus;
        //    this.store = store;
        //    this.contextManager = contextManager;
        //}

        public CommitDispatchConsumer(IBus bus, IDocumentStore store, IOperationContextManager contextManager)
        {
            Ensure.That(bus).Named(() => bus).IsNotNull();
            Ensure.That(store).Named(() => store).IsNotNull();
            Ensure.That(contextManager).Named(() => contextManager).IsNotNull();

            this.bus = bus;
            _store = store;
            _contextManager = contextManager;
        }

        protected override void Dispatch(Commit commit)
        {
            foreach (IDomainEvent @event in commit.Events)
            {
                bus.Publish(@event);
            }
        }
    }
}