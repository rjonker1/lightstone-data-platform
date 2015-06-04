using System;
using System.Linq;
using Lim.Enums;
using Lim.Schedule.Core;
using Lim.Schedule.Core.Commands;
using Lim.Test.Helper.Fakes.Handlers;
using Xunit.Extensions;

namespace Lim.Unit.Tests.Jobs.Api
{
    public class when_pushing_always_on_api_job : Specification
    {
        private readonly IHandleFetchingApiPushConfiguration _fetch;
        private readonly IHandleExecutingApiConfiguration _handler;

        public when_pushing_always_on_api_job()
        {
            _fetch = new FakeFetchingApiPushConfigurationHandler();
            _handler = new FakeHandleExecutingApiConfiguration();
        }

        public override void Observe()
        {
            _fetch.Handle(new FetchConfigurationForClientCommand(IntegrationAction.Push, IntegrationType.Api, Frequency.AlwaysOn, new Guid("B63F6F0C-D26A-4959-9E75-7C8C485CC495"), new Guid("390CD416-FC52-4A0B-98CE-8E8940212354")));
        }

        [Observation]
        public void then_custom_api_push_job_should_be_fetched()
        {
            _fetch.Configurations.Any().ShouldBeTrue();
        }

        [Observation]
        public void then_custom_api_push_job_should_be_handled()
        {
            _handler.Handle(new ExecuteApiPushConfigurationCommand(_fetch.Configurations));
            _handler.IsHandled.ShouldEqual(true);
        }
    }
}
