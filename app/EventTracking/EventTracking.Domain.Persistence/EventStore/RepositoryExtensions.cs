using System;

namespace EventTracking.Domain.Persistence.EventStore
{
    public static class RepositoryExtensions
    {
        public static void Save(this IWriteToEventTrackingRepository repository, IAggregate aggregate, Guid commitId)
        {
            repository.Write(aggregate, commitId, a => { });
        }
    }
}
