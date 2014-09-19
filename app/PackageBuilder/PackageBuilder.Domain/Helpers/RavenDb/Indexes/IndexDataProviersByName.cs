using PackageBuilder.Domain.DataProviders.ReadModels;
using PackageBuilder.Domain.DataProviders.WriteModels;
using Raven.Client.Indexes;
using System.Linq;

namespace PackageBuilder.Domain.Helpers.RavenDb.Indexes
{
    public class IndexDataProviersByName : AbstractIndexCreationTask<DataProvider, DataProviderReadModel> 
    {
        public IndexDataProviersByName()
        {
            Map = dataProviders => dataProviders.Select(x => new { x.Id, x.Name, x.Version });
        }
    }
}