using System;
using System.Linq.Expressions;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.Processes
{
    // TODO: Does this even belong to a reusable infrastructure?
    // This for reading and writing process managers (also known as Sagas in the CQRS community)
    public interface IProcessManagerDataContext<T> : IDisposable
        where T : class, IProcessManager
    {
        T Find(Guid id);

        void Save(T processManager);

        // TODO: query-ability to reload processes from correlation ids, etc. 
        // Is this appropriate? How do others reload processes? (MassTransit 
        // uses this kind of queryable approach, apparently).
        T Find(Expression<Func<T, bool>> predicate, bool includeCompleted = false);
    }
}
