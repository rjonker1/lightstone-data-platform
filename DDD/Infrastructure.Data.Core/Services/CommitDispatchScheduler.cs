using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using LightstoneApp.Infrastructure.Data.Core.Commits;
using LightstoneApp.Infrastructure.Data.Core.Runtime;
using Raven.Client;
using Topics.Radical.Bootstrapper;

namespace LightstoneApp.Infrastructure.Data.Core.Services
{
    internal class CommitDispatchScheduler : AbstractDispatchScheduler<Commit, CommitDispatchConsumer>,
        ICommitDispatchScheduler, IRequireToStart
    {
        private readonly IBus bus;
        private readonly IOperationContextManager contextManager;
        private readonly IDocumentStore store;

        public CommitDispatchScheduler(IDocumentStore store, IBus bus, IOperationContextManager contextManager)
            : base(store)
        {
            this.store = store;
            this.contextManager = contextManager;
            this.bus = bus;
        }

        public bool IsSynchronous
        {
            get { return true; }
        }

        public void Start()
        {
            TryResume();
        }

        protected override CommitDispatchConsumer CreateConsumer()
        {
            var consumer = new CommitDispatchConsumer(bus, store, contextManager);

            return consumer;
        }
    }
}