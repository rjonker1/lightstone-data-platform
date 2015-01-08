using DataPlatform.Shared.Enums;
using Monitoring.Dashboard.UI.Core.Contracts.Services;
using Nancy;

namespace Monitoring.Dashboard.UI.Modules
{
    public class DataProviderModule : NancyModule
    {
        public DataProviderModule(ICallMonitoringService service)
        {
            Get["/dataProviders"] = _ =>
            {
                var model = service.GetMonitoringInformationBySource((int) MonitoringSource.Lace);
                return View["Monitoring", model];
            };
        }
    }
}