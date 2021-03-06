﻿using Nancy.Testing;
using PackageBuilder.Api.Installers;
using PackageBuilder.Api.Modules;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.CommandHandlers;
using PackageBuilder.Domain.Entities.States.Read;
using PackageBuilder.TestHelper.BaseTests;
using PackageBuilder.TestObjects.Mothers;
using Xunit;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests.Modules.States
{
    public class when_invoking_state_route : TestDataBaseHelper
    {
        private Browser _browser;
        private BrowserResponse _response;

        public override void Observe()
        {
            base.RefreshDb();

            Container.Install(new BusInstaller(), new RepositoryInstaller());

            SaveAndFlush(StateMother.Draft, StateMother.Published);

            _browser = new Browser(with =>
            {
                with.Module(new StateModule(Container.Resolve<IPublishStorableCommands>(), Container.Resolve<IRepository<State>>()));
            });

            _response = _browser.Get("/State", with =>
            {
                with.HttpRequest();
                //with.Header("Authorization", "ApiKey 4E7106BA-16B6-44F2-AF4C-D1C411440F8E");
            });
        }

        [Fact(Skip = "Not necessary could be double work effort, decided to rely on ui tests as acceptance tests")]
        public void should_return_all_states_as_json()
        {
            _response.Body.AsString().ShouldNotBeNull();
            _response.Body.AsString().ShouldContain("Draft");
            _response.Body.AsString().ShouldContain("Published");
        }
    }
}