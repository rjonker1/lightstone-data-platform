using System.Text;
using DataPlatform.Shared.Enums;
using Monitoring.Dashboard.UI.Core.Contracts.Services;
using Monitoring.Dashboard.UI.Core.Extensions;
using Nancy;

namespace Monitoring.Dashboard.UI.Modules
{
    public class DataProviderModule : NancyModule
    {
        public DataProviderModule(ICallMonitoringService service)
        {
           
            Get["/dataProviders/log"] = _ => View["MonitoringDataProviders"];
          
            Get["/dataProviders/freshenLog"] = _ =>
            {
                var model = service.GetMonitoringInformationBySource((int)MonitoringSource.Lace).AsJsonString();

                var bytes = Encoding.UTF8.GetBytes(model);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(bytes, 0, bytes.Length)
                };

            };
        }
    }
}