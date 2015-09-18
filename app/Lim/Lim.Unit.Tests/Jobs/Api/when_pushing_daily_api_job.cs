using System.Linq;
using Lim.Enums;
using Lim.Schedule.Core;
using Lim.Schedule.Core.Commands;
using Lim.Test.Helper.Fakes.Handlers;
using Xunit.Extensions;

namespace Lim.Unit.Tests.Jobs.Api
{
    public class when_pushing_daily_api_job : Specification
    {
        private readonly IHandleFetchingApiPushConfiguration _fetch;
        private readonly IHandleExecutingApiConfiguration _handler;

        public when_pushing_daily_api_job()
        {
            _fetch = new FakeFetchingApiPushConfigurationHandler();
            _handler = new FakeHandleExecutingApiConfiguration();
        }

        public override void Observe()
        {
            _fetch.Handle(new FetchConfigurationCommand(IntegrationAction.Push, IntegrationType.Api, Frequency.Daily));
        }

        [Observation(Skip = "Need to redo test")]
        public void then_custom_api_push_job_should_be_fetched()
        {
            _fetch.Configurations.Any().ShouldBeTrue();
        }

        [Observation(Skip = "Need to redo test")]
        public void then_custom_api_push_job_should_be_handled()
        {
            _handler.Handle(new ExecuteApiPushConfigurationCommand(_fetch.Configurations));
            _handler.IsHandled.ShouldEqual(true);
        }
    }
}