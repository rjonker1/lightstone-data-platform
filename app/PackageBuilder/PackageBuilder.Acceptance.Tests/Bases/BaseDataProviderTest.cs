using System;
using Nancy.Testing;
using PackageBuilder.Api.Installers;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities.DataProviders.Write;

namespace PackageBuilder.Acceptance.Tests.Bases
{
    public abstract class BaseDataProviderTest : BaseModuleTest
    {
        protected Guid Id = Guid.NewGuid();
        protected DataProvider DataProvider;
        protected INEventStoreRepository<DataProvider> WriteRepo;
        protected IHandleMessages Handler;
        protected BrowserResponse Response;

        protected BaseDataProviderTest()
        {
            RefreshDb();

            Container.Install(new WindsorInstaller());

            WriteRepo = Container.Resolve<INEventStoreRepository<DataProvider>>();
            Handler = Container.Resolve<IHandleMessages>();
        }

        public override void Observe()
        {
            
        }
    }
}