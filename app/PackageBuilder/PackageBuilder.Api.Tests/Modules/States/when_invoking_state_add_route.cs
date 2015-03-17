using Nancy.Testing;
using PackageBuilder.Api.Installers;
using PackageBuilder.Api.Modules;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.CommandHandlers;
using PackageBuilder.Domain.Entities.States.Read;
using PackageBuilder.TestHelper.BaseTests;
using Xunit;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.Modules.States
{
    public class when_invoking_state_add_route : when_persisting_entities_to_db
    {
        private Browser _browser;
        private BrowserResponse _response;

        public override void Observe()
        {
            base.Observe();

            Container.Install(new BusInstaller(), new RepositoryInstaller(), new CommandInstaller());

            _browser = new Browser(with =>
            {
                with.Module(new StateModule(Container.Resolve<IPublishStorableCommands>(), Container.Resolve<IRepository<State>>()));
            });

            Transaction(Session =>
            {
                _response = _browser.Post("/State/Add", with =>
                {
                    with.HttpRequest();
                    with.Body("{'name': 'Draft'}");
                    with.Header("content-type", "application/json");
                    //with.Header("Authorization", "ApiKey 4E7106BA-16B6-44F2-AF4C-D1C411440F8E");
                });
            });
        }

        [Fact(Skip = "Not necessary could be double work effort, decided to rely on ui tests as acceptance tests")]
        [Observation]
        public void should_return_success_response()
        {
            _response.Body.AsString().ShouldNotBeNull();
            _response.Body.AsString().ShouldContain("Success!");
        }
    }
}