using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Lim.Domain.Entities.Factory;
using Lim.Domain.Entities.Repository;
using Lim.Enums;
using Lim.Schedule.Core;
using Lim.Schedule.Core.Audits;
using Lim.Schedule.Core.Commands;
using Lim.Schedule.Core.Handlers;
using Lim.Schedule.Core.Tracking;
using NHibernate;
using Xunit.Extensions;
using IntegrationType = Lim.Enums.IntegrationType;

namespace Lim.Acceptance.Tests.Integrations.Push
{
    public class when_pushing_hourly_integration :  Specification
    {
       // private readonly IJob _job; 
        private readonly IHandleFetchingApiPushConfiguration _fetch;
        private readonly IHandleExecutingApiConfiguration _execute;
     
        private readonly IDbConnection _connection;
        private readonly IAuditIntegration _audit;
        private readonly IAmRepository _entityRepository;
        private readonly ITrackIntegration _tracking;
        private readonly ISession _session;

        private readonly FetchConfigurationCommand _fetchCommand = new FetchConfigurationCommand(IntegrationAction.Push, IntegrationType.Api, Frequency.Hourly);
        private ExecuteApiPushConfigurationCommand _executeCommand;

        private readonly ApiIntegrationTestSetup _setup;

        public when_pushing_hourly_integration()
        {
            //_entityRepository = new LimRepository(SessionFactory.BuildSession("lim/schedule/database").OpenSession());
            _entityRepository = new LimRepository();
            _session = FactoryManager.Instance.OpenSession();

            _connection = new SqlConnection(
                ConfigurationManager.ConnectionStrings["lim/schedule/database"].ToString());
            _audit = new StoreIntegrationAudit(_entityRepository);
            _tracking = new TrackIntegration(_entityRepository);

            _fetch = new HandleFetchingApiPushConfiguration(_entityRepository);
            _execute = new HandleExecutingApiConfiguration(_entityRepository, _audit, _tracking);

            _setup = new ApiIntegrationTestSetup(_session, _entityRepository);
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
            _fetch.Configurations.ShouldNotBeNull();
            _fetch.Configurations.Any().ShouldBeTrue();
            foreach (var config in _fetch.Configurations)
            {
                var record = _setup.GetAuditLog(config.ConfigurationId);
                record.ShouldNotBeNull();
                record.WasSuccessful.ShouldBeTrue();
            }
        }

       
    }
}
