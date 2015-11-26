using Nancy.Testing;
using NHibernate;
using PackageBuilder.Api.Installers;
using PackageBuilder.Api.Modules;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.CommandHandlers;
using PackageBuilder.Domain.Entities.States.Read;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers;
using Xunit;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests.Api.Modules.States
{
    public class when_invoking_state_edit_route : TestDataBaseHelper
    {
        private Browser _browser;
        private BrowserResponse _response;

        public override void Observe()
        {
            base.RefreshDb();

            Container.Install(new BusInstaller(), new RepositoryInstaller(), new CommandInstaller());

            var state = StateMother.Draft;
            SaveAndFlush(state, StateMother.Published);



            var id = GetFromDb(state).Id;
            _browser = new Browser(with =>
            {
                with.Module(new StateModule(Container.Resolve<IPublishStorableCommands>(), Container.Resolve<IRepository<State>>()));
            });

            Session.FlushMode = FlushMode.Never;

            //Transaction(x =>
            //{
            _response = _browser.Post("/State/Edit", with =>
            {
                with.HttpRequest();
                with.Body("{ 'id': '" + id + "', 'name': 'Draft', 'alias': 'Test Draft'}");
                with.Header("content-type", "application/json");
                //with.Header("Authorization", "ApiKey 4E7106BA-16B6-44F2-AF4C-D1C411440F8E");
            });
            //});

            Session.Flush();
            // Session.Close();
        }

        [Fact(Skip = "Not necessary could be double work effort, decided to rely on ui tests as acceptance tests")]
        public void should_return_success_response()
        {
            _response.Body.AsString().ShouldNotBeNull();
            _response.Body.AsString().ShouldContain("Success!");
        }
    }
}