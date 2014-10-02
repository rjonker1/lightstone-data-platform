using System.Linq;
using NEventStore.Persistence.RavenDB;
using PackageBuilder.Domain.Models;
using PackageBuilder.Domain.DataProviders.ReadModels;
using PackageBuilder.Domain.DataProviders.WriteModels;
using Raven.Client.Indexes;

namespace PackageBuilder.Infrastructure.RavenDB.Indexes
{
    public class IndexAllDataProviders : AbstractIndexCreationTask<ReadDataProvider>
    {

        public class ReduceResult
        {
            public int Count { get; set; }
        }

        public IndexAllDataProviders()
        {

            Map = dataProvidersMeta => from dataProvider in dataProvidersMeta
                select new ReadDataProvider
                {

                    Id = dataProvider.Id,
                    Name = dataProvider.Name,
                    Version = dataProvider.Version

                };



            //dataProviders.Select(x => new { x.BucketId });

        }
    }
}