using System.Linq;
using PackageBuilder.Domain.Entities.Packages.ReadModels;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace PackageBuilder.Infrastructure.RavenDB.Indexes
{
    public class IndexAllPackages : AbstractIndexCreationTask<ReadPackage> 
    {
        public IndexAllPackages()
        {
            Map = packages => from package in packages
                              select new {package.Id};

            Index(x => x.Id, FieldIndexing.Analyzed);
        }
    }
}