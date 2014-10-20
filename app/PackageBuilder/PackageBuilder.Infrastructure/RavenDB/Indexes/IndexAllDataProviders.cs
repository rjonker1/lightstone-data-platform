using System;
using System.Linq;
using PackageBuilder.Domain.Entities.DataProviders.ReadModels;
using Raven.Client.Indexes;

namespace PackageBuilder.Infrastructure.RavenDB.Indexes
{
    public class IndexAllDataProviders : AbstractIndexCreationTask<DataProvider>
    {
        public class ReduceResult
        {
            public int Count { get; set; }
        }

        public IndexAllDataProviders()
        {

            Map = dataProvidersMeta => from dataProvider in dataProvidersMeta
                                       select new DataProvider(Guid.NewGuid(), dataProvider.Id, dataProvider.Name, 0d, dataProvider.Description, dataProvider.Owner);
        }
    }
}