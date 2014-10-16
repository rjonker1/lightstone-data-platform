using Topics.Radical.Validation;

namespace LightstoneApp.Infrastructure.Data.Core.Runtime
{
    internal abstract class AbstractDispatchConsumer<T> where T : class
    {
        protected abstract void Dispatch(T item);

        public virtual void ScheduleDispatch(T item)
        {
            Ensure.That(item).Named(() => item).IsNotNull();

            Dispatch(item);
        }
    }
}