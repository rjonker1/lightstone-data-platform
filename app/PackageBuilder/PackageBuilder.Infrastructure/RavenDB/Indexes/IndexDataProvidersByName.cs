using System.Linq;
using PackageBuilder.Domain.DataProviders.ReadModels;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace PackageBuilder.Infrastructure.RavenDB.Indexes
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