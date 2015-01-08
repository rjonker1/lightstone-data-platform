using System.Collections.Generic;
using Monitoring.Dashboard.UI.Core.Models;
using Monitoring.Dashboard.UI.Infrastructure.Commands;

namespace Monitoring.Dashboard.UI.Core.Contracts.Handlers
{
    public interface IHandleDataProviderCommands
    {
        IEnumerable<MonitoringResponse> DataProviders { get; }
        void Handle(GetDataProviderViewCommand command);
    }
}
