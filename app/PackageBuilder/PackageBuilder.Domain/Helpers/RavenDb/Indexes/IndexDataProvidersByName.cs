using System;
using PackageBuilder.Domain.DataProviders.ReadModels;
using PackageBuilder.Domain.DataProviders.WriteModels;
using Raven.Abstractions.Indexing;
using Raven.Client.Document;
using Raven.Client.Indexes;
using System.Linq;

namespace PackageBuilder.Domain.Helpers.RavenDb.Indexes
{
    public class IndexDataProvidersByName : AbstractIndexCreationTask<DataProviderReadModel> 
    {

        public IndexDataProvidersByName()
        {

            Map = dataProviders => from dataProv in dataProviders
                select new { dataProv.Id};

            Index(x => x.Id, FieldIndexing.Analyzed);

            //dataProviders.Select(x => new { DapId = x.Id, DapName = x.Name, DapVersion = x.Version});

        }
    }
}