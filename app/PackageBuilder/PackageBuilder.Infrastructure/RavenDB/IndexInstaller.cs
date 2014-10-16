using Castle.Windsor;
using PackageBuilder.Infrastructure.RavenDB.Indexes;
using Raven.Client;
using Raven.Client.Indexes;

namespace PackageBuilder.Infrastructure.RavenDB
{
    public class IndexInstaller
    {
        public static void Install(IWindsorContainer container)
        {
            IndexCreation.CreateIndexes(typeof(IndexAllPackages).Assembly, container.Resolve<IDocumentStore>());
            IndexCreation.CreateIndexes(typeof(IndexAllDataProviders).Assembly, container.Resolve<IDocumentStore>());
        }
    }
}