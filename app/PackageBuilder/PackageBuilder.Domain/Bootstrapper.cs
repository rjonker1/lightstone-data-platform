using Castle.Windsor;
using Castle.Windsor.Installer;
using PackageBuilder.Domain.Helpers.RavenDb.Indexes;
using Raven.Client;
using Raven.Client.Indexes;

namespace PackageBuilder.Domain
{
    public static class Bootstrapper
    {
        public static void Startup(IWindsorContainer windsorContainer)
        {
            windsorContainer.Install(FromAssembly.This());

            IndexCreation.CreateIndexes(typeof(IndexDataProviersByName).Assembly, windsorContainer.Resolve<IDocumentStore>());
        }
    }
}