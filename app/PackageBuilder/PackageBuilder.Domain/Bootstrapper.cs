using System.Linq;
using Castle.Windsor;
using Castle.Windsor.Installer;
using PackageBuilder.Domain.DataProviders.ReadModels;
using PackageBuilder.Domain.DataProviders.WriteModels;
using Raven.Abstractions.Indexing;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Indexes;

namespace PackageBuilder.Domain
{
    public static class Bootstrapper
    {
        public static void Startup(IWindsorContainer windsorContainer)
        {
            //windsorContainer.Install(FromAssembly.This());


            //DocumentStore documentStore = new DocumentStore { Url = "http://localhost:8080" };
            //documentStore.Initialize();


            //documentStore.DatabaseCommands.PutIndex("IndexDataProviersByName",
            //    new IndexDefinitionBuilder<DataProvider>
            //    {
            //        Map = dataProviders => dataProviders.Select(x => new { x.Id, x.Name, x.Version })
            //    });

        }
    }
}