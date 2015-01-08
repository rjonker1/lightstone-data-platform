using System.Collections.Generic;
using Monitoring.Dashboard.UI.Core.Models;

namespace Monitoring.Dashboard.UI.Core.Contracts.Repositories
{
    public interface IDataProviderRepository
    {
        IEnumerable<MonitoringResponse> GetAllDataProviderInformation();
    }
}
