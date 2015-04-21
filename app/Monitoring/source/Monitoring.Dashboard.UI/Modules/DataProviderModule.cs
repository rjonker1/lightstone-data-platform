using System.Text;
using Monitoring.Dashboard.UI.Core.Contracts.Services;
using Monitoring.Dashboard.UI.Core.Extensions;
using Nancy;

namespace Monitoring.Dashboard.UI.Modules
{
    public class DataProviderModule : NancyModule
    {
        public DataProviderModule(ICallMonitoringService service)
        {

            Get["/dataProviders/log"] = _ => View["DataProviders"];

            Get["/dataProviders/freshenLog"] = _ =>
            {
                var model = service.GetMonitoringForDataProviders().AsJsonString();

                var bytes = Encoding.UTF8.GetBytes(model);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(bytes, 0, bytes.Length)
                };

            };

            Get["/dataProviders/freshenStatistics"] = _ =>
            {
                var model = service.GetDataProviderStatistics().AsJsonString();
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