using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using LightstoneApp.Infrastructure.Data.Core.Runtime;
using Raven.Client;
using Topics.Radical.Bootstrapper;

namespace LightstoneApp.Infrastructure.Data.Core.Services
{
    class CommitDispatchScheduler : AbstractDispatchScheduler<Commits.Commit, CommitDispatchConsumer>, ICommitDispatchScheduler, IRequireToStart
	{
		readonly IOperationContextManager contextManager;
		readonly IBus bus;
		readonly IDocumentStore store;

		public CommitDispatchScheduler( IDocumentStore store, IBus bus, IOperationContextManager contextManager )
			: base( store )
		{
			this.store = store;
			this.contextManager = contextManager;
			this.bus = bus;
		}

		protected override CommitDispatchConsumer CreateConsumer()
		{
			var consumer = new CommitDispatchConsumer( this.bus, this.store, this.contextManager );

			return consumer;
		}

		public void Start()
		{
			this.TryResume();
		}

		public bool IsSynchronous
		{
			get { return true; }
		}
	}
}
