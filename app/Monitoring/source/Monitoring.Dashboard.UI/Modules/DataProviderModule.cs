using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using Monitoring.Dashboard.UI.Core.Contracts.Services;
using Monitoring.Dashboard.UI.Core.Models;
using Nancy;

namespace Monitoring.Dashboard.UI.Modules
{
    public class DataProviderModule : NancyModule
    {
        public DataProviderModule(ICallMonitoringService service)
        {
            Get["/dataProviders/summary"] = _ =>
            {
                var model = new List<MonitoringResponse>();
                return View["MonitoringDataProviders", model];
            };

            Get["/dataProviders/log"] = _ =>
            {
                var model = service.GetMonitoringInformationBySource((int) MonitoringSource.Lace);
                return View["MonitoringDataProviders", model];
            };

            Get["/dataProviders/updatedLog"] = _ =>
            {
                return new {result = "result"};
            };
        }
    }
}