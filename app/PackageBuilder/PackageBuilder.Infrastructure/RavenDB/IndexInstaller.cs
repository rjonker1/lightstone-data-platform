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
            IndexCreation.CreateIndexes(typeof(IndexDataProvidersByName).Assembly, container.Resolve<IDocumentStore>());
            IndexCreation.CreateIndexes(typeof(TestingIndex).Assembly, container.Resolve<IDocumentStore>());
            IndexCreation.CreateIndexes(typeof(ReadIndexTest).Assembly, container.Resolve<IDocumentStore>());
        }
    }
}