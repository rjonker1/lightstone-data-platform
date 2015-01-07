using Monitoring.Dashboard.UI.Core.Contracts.Services;
using Nancy;

namespace Monitoring.Dashboard.UI.Modules
{
    public class DataProviderModule : NancyModule
    {
        public DataProviderModule(ICallDataProviderService service)
        {
            Get["/dataProviders"] = _ =>
            {
                var model = service.GetDataProviderMonitoringInformation();
                return View["DataProviders", model];
            };
        }
    }
}