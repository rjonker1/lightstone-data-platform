using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Windsor;
using Castle.Windsor.Installer;
using PackageBuilder.Core.Helpers.RavenDb.Indexes;
using PackageBuilder.Core.Helpers.Windsor.Installers;
using Raven.Client;
using Raven.Client.Indexes;

namespace PackageBuilder.Core
{
    public static class Bootstrapper
    {

        public static void Startup(IWindsorContainer windsorContainer)
        {
            //windsorContainer.Install(FromAssembly.This());
            windsorContainer.Install(
                    new CommandInstaller(), 
                    new EventStoreInstaller(), 
                    new NHibernateInstaller(), 
                    new RavenDbInstaller());

            IndexCreation.CreateIndexes(typeof(IndexDataProvidersByName).Assembly, windsorContainer.Resolve<IDocumentStore>());
            IndexCreation.CreateIndexes(typeof(TestingIndex).Assembly, windsorContainer.Resolve<IDocumentStore>());
        }

    }
}
