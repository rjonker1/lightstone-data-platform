using System.Collections.Generic;
using System.Linq;
using Monitoring.Dashboard.UI.Core.Contracts.Handlers;
using Monitoring.Dashboard.UI.Core.Contracts.Repositories;
using Monitoring.Dashboard.UI.Core.Models;
using Monitoring.Dashboard.UI.Infrastructure.Commands;

namespace Monitoring.Dashboard.UI.Infrastructure.Handlers
{
    public class MonitoringHandler : IHandleMonitoringCommands
    {
        private readonly IMonitoringRepository _repository;
        public IEnumerable<MonitoringResponse> MonitoringResponse { get; private set; }
        public MonitoringResponse MonitoringResponseItem { get; private set; }

        public MonitoringHandler(IMonitoringRepository repository)
        {
            _repository = repository;
        }

        public void Handle(GetMonitoringCommand command)
        {
            MonitoringResponse = _repository.GetAllMonitoringInformation(command.Request.SourceId).ToList();
        }

        public void Handle(GetMonitoringItemCommand command)
        {
            MonitoringResponseItem = _repository.GetMonitoringResponseItem(command.Request.Id, command.Request.SourceId);
        }
    }
}