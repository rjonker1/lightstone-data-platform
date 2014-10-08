using Topics.Radical.Validation;

namespace LightstoneApp.Infrastructure.Data.Core.Runtime
{
	abstract class AbstractDispatchConsumer<T> where T: class
	{
		protected AbstractDispatchConsumer()
		{
			
		}

		protected abstract void Dispatch( T item );

		public virtual void ScheduleDispatch( T item )
		{
			Ensure.That( item ).Named( () => item ).IsNotNull();

			this.Dispatch( item );
		}
	}
}
