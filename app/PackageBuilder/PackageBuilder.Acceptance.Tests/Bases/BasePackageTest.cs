using System;
using Nancy.Testing;
using PackageBuilder.Api.Installers;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities.Packages.Write;

namespace PackageBuilder.Acceptance.Tests.Bases
{
    public abstract class BasePackageTest : BaseModuleTest
    {
        protected Guid Id = Guid.NewGuid();
        protected Package Package;
        protected INEventStoreRepository<Package> WriteRepo;
        protected IHandleMessages Handler;
        protected BrowserResponse Response;

        protected BasePackageTest()
        {
            RefreshDb(false);

            Container.Install(new WindsorInstaller());

            WriteRepo = Container.Resolve<INEventStoreRepository<Package>>();
            Handler = Container.Resolve<IHandleMessages>();
        }

        public override void Observe()
        {

        }
    }
}