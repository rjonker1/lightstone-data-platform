using System.Linq;
using DataPlatform.Shared.Entities;
using NEventStore.Persistence.RavenDB;
using PackageBuilder.Domain.DataProviders.ReadModels;
using PackageBuilder.Domain.DataProviders.WriteModels;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace PackageBuilder.Domain.Helpers.RavenDb.Indexes
{
    public class TestingIndex : AbstractIndexCreationTask<RavenCommit, DataProviderReadModel>
    {

        public class ReduceResult
        {
            public int Count { get; set; }
        }

        public TestingIndex()
        {

            Map = commits => from commit in commits
                from payload in commit.Payload
                select new DataProviderReadModel
                {

                    Id = ((DataProvider)payload.Body).Id,
                    Name = ((DataProvider)payload.Body).Name

                };



            //dataProviders.Select(x => new { x.BucketId });

        }
    }
}