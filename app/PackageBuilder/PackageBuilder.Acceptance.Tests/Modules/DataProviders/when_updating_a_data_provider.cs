using System;
using Nancy.Testing;
using PackageBuilder.Acceptance.Tests.Fakes;
using PackageBuilder.Api.Helpers.Constants;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.TestHelper.BaseTests;
using Xunit;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests.Modules.DataProviders
{
    public class when_updating_the_lightStone_data_provider : MemoryTestDataBaseHelper
    {
        private Guid _id = Guid.NewGuid();
        private Browser _browser;
        private BrowserResponse _response;
        private INEventStoreRepository<DataProvider> _writeRepo;
        private IHandleMessages _handler;

        public when_updating_the_lightStone_data_provider()
        {
            base.RefreshDb();

            //Container.Install(new WindsorInstaller(), new BusInstaller(), new NEventStoreInstaller(), new RepositoryInstaller(), new CommandInstaller());

            //_handler = Container.Resolve<IHandleMessages>();
            //_handler.Handle(new CreateDataProvider(_id, DataProviderName.LightstoneAuto, 0, "Owner", DateTime.UtcNow));

            //_browser = new Browser(with =>
            //{
            //    _writeRepo = Container.Resolve<INEventStoreRepository<DataProvider>>();
            //    with.Module(new DataProviderModule(Container.Resolve<IPublishStorableCommands>(), Container.Resolve<IDataProviderRepository>(), _writeRepo, Container.Resolve<IRepository<State>>()));
            //});

            _browser = new Browser(new TestBootstrapper());

            Transaction(Session =>
            {
                _response = _browser.Put(RouteConstants.DataProviderEditRoute.Replace("{id}", _id.ToString()), with =>
                {
                    with.HttpRequest();
                    with.Body("{'name': 'Draft'}");
                    with.Header("content-type", "application/json");
                    //with.Header("Authorization", "ApiKey 4E7106BA-16B6-44F2-AF4C-D1C411440F8E");
                });
            });
        }

        public override void Observe()
        {
            
        }

        [Fact(Skip = "Not necessary could be double work effort, decided to rely on ui tests as acceptance tests")]
        public void should_return_success_response()
        {
            _response.Body.AsString().ShouldNotBeNull();
            _response.Body.AsString().ShouldContain("Success!");
        }
    }
}