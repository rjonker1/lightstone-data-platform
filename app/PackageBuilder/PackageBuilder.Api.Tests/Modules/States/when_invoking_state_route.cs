using MemBus;
using Nancy.Testing;
using PackageBuilder.Api.Installers;
using PackageBuilder.Api.Modules;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.Entities.States.WriteModels;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers;
using Xunit;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.Modules.States
{
    public class when_invoking_state_route : when_persisting_entities_to_db
    {
        private Browser _browser;
        private BrowserResponse _response;

        public override void Observe()
        {
            base.Observe();

            Container.Install(new BusInstaller(), new RepositoryInstaller());

            SaveAndFlush(StateMother.Draft, StateMother.Published);

            _browser = new Browser(with =>
            {
                with.Module(new StateModule(Container.Resolve<IBus>(), Container.Resolve<IRepository<State>>()));
            });

            _response = _browser.Get("/State", with =>
            {
                with.HttpRequest();
                //with.Header("Authorization", "ApiKey 4E7106BA-16B6-44F2-AF4C-D1C411440F8E");
            });
        }

        [Fact(Skip = "Not necessary could be double work, decided to rely on ui tests as acceptance tests")]
        [Observation]
        public void should_return_all_states_as_json()
        {
            _response.Body.AsString().ShouldNotBeNull();
            _response.Body.AsString().ShouldContain("Draft");
            _response.Body.AsString().ShouldContain("Published");
        }
    }
}