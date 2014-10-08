using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using Raven.Client;
using Topics.Radical.Validation;

namespace LightstoneApp.Infrastructure.Data.Core.Runtime
{
	class CommitDispatchConsumer : AbstractDispatchConsumer<Commits.Commit>
	{
		readonly IOperationContextManager _contextManager;
		readonly IBus bus;
		readonly IDocumentStore _store;
		
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
			this._store = store;
			this._contextManager = contextManager;
		}

		protected override void Dispatch( Commits.Commit commit )
		{
			foreach ( var @event in commit.Events )
			{
				bus.Publish( @event );
			}
		}
	}
}
