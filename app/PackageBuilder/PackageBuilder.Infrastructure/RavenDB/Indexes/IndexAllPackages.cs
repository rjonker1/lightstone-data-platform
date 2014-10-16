using System.Linq;
using PackageBuilder.Domain.Entities.Packages.ReadModels;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;
using FluentNHibernate.Data;

namespace PackageBuilder.Infrastructure.RavenDB.Indexes
{
    public class IndexAllPackages : AbstractIndexCreationTask<Package> 
    {
        public IndexAllPackages()
        {
            Map = packages => from package in packages
                              select new {package.Id};

            Index(x => x.Id, FieldIndexing.Analyzed);
        }
    }
}