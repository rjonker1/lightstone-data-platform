using System.Collections.Generic;
using LightstoneApp.Infrastructure.Data.Core.Commits;
using LightstoneApp.Infrastructure.Data.Core.Runtime;
using Raven.Client;
using Topics.Radical.Validation;

namespace LightstoneApp.Infrastructure.Data.Core.Services
{
	abstract class AbstractDispatchScheduler<TCommit, TConsumer>
		where TConsumer : AbstractDispatchConsumer<TCommit>
		where TCommit : Commit
	{
		readonly IDocumentStore documentStore;
		TConsumer consumer = null;

		public AbstractDispatchScheduler( IDocumentStore documentStore )
		{
			Ensure.That( documentStore ).Named( () => documentStore ).IsNotNull();

			this.documentStore = documentStore;
		}

		protected virtual void TryResume()
		{
			//using ( var session = this.documentStore.OpenSession() )
			//{
			//	var query = session.Query<TCommit>( "Commits/ByCreatedOnAndIsDispatchedSortByCreatedOn" )
			//			.Where( c => c.IsDispatched == false )
			//			.OrderBy( c => c.CreatedOn );

			//	var all = session.Advanced.Stream( query );
			//	while ( all.MoveNext() )
			//	{
			//		this.ScheduleDispatch( all.Current.Document );
			//	}
			//}
		}

		public virtual void ScheduleDispatch( IEnumerable<TCommit> commits )
		{
			foreach ( var commit in commits )
			{
				this.ScheduleDispatch( commit );
			}
		}

		protected abstract TConsumer CreateConsumer();

		public virtual void ScheduleDispatch( TCommit commit )
		{
			if ( this.consumer == null ) 
			{
				this.consumer = this.CreateConsumer();
			}

			this.consumer.ScheduleDispatch( commit );
		}
	}
}
