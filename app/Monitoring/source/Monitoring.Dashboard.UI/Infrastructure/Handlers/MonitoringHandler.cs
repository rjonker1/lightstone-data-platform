using System.Collections.Generic;
using System.Linq;
using Monitoring.Dashboard.UI.Core.Contracts.Handlers;
using Monitoring.Dashboard.UI.Core.Models;
using Monitoring.Dashboard.UI.Infrastructure.Commands;
using Monitoring.Dashboard.UI.Infrastructure.Repository;
using Monitoring.Domain.Repository;

namespace Monitoring.Dashboard.UI.Infrastructure.Handlers
{
    public class MonitoringHandler : IHandleMonitoringCommands
    {
        private readonly IMonitoringRepository _repository;
        public IEnumerable<MonitoringDataProvider> MonitoringResponse { get; private set; }

        public MonitoringHandler(IMonitoringRepository repository)
        {
            _repository = repository;
        }

        public void Handle(GetMonitoringCommand command)
        {
            MonitoringResponse =
                _repository.Items<MonitoringDataProvider>(SelectStatements.GetDataProviderRequestResponses);
        }

    }
}