using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Lim.Domain.Repository;
using Lim.Enums;
using Lim.Schedule.Core;
using Lim.Schedule.Core.Audits;
using Lim.Schedule.Core.Commands;
using Lim.Schedule.Core.Handlers;
using Xunit.Extensions;
using IntegrationType = Lim.Enums.IntegrationType;

namespace Lim.Acceptance.Tests.Integrations.Push
{
    public class when_pushing_hourly_integration :  Specification
    {
       // private readonly IJob _job; 
        private readonly IHandleFetchingApiPushConfiguration _fetch;
        private readonly IHandleExecutingApiConfiguration _execute;
        private readonly ILimRepository _limRepository;
        private readonly IRepository _repository;
        private readonly IDbConnection _connection;
        private readonly IAuditIntegration _audit;

        private readonly FetchConfigurationCommand _fetchCommand = new FetchConfigurationCommand(IntegrationAction.Push, IntegrationType.Api, Frequency.Hourly);
        private ExecuteApiPushConfigurationCommand _executeCommand;

        private readonly ApiIntegrationTestSetup _setup;

        public when_pushing_hourly_integration()
        {

            _connection = new SqlConnection(
                ConfigurationManager.ConnectionStrings["lim/schedule/database"].ToString());
            _repository = new Repository(_connection);
            _limRepository = new LimRepository(_connection);
            _audit = new StoreIntegrationAudit(_connection);

            _fetch = new HandleFetchingApiPushConfiguration(_repository);
            _execute = new HandleExecutingApiConfiguration(_limRepository, _audit);

            _setup = new ApiIntegrationTestSetup(_connection);
           // _job = new Lim.Schedule.Integrations.Daily.Api.PushJob(_fetch, _execute);
        }

        public override void Observe()
        {
            _setup.DeleteAllAudits();

            _fetch.Handle(_fetchCommand);
            _executeCommand = new ExecuteApiPushConfigurationCommand(_fetch.Configurations);
            _execute.Handle(_executeCommand);
        }

        [Observation]
        public void then_configuration_for_hourl_push_must_be_successful()
        {
            _fetch.Configurations.Any().ShouldBeTrue();
            foreach (var config in _fetch.Configurations)
            {
                var record = _setup.GetAuditLog(config.Key);
                record.ShouldNotBeNull();
                record.WasSuccessful.ShouldBeTrue();
            }
        }

       
    }
}
