using Castle.Windsor;
using PackageBuilder.Core.Helpers.RavenDb.Indexes;
using Raven.Client;
using Raven.Client.Indexes;

namespace PackageBuilder.Api.Helpers.RavenDB
{
    public class IndexInstaller
    {
        public static void Install(IWindsorContainer container)
        {
            IndexCreation.CreateIndexes(typeof(IndexDataProvidersByName).Assembly, container.Resolve<IDocumentStore>());
            IndexCreation.CreateIndexes(typeof(TestingIndex).Assembly, container.Resolve<IDocumentStore>());
        }
    }
}