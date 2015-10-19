using System.Text;
using DataPlatform.Shared.Enums;
using Monitoring.Dashboard.UI.Core.Contracts.Services;
using Monitoring.Dashboard.UI.Core.Extensions;
using Nancy;
using Nancy.Security;

namespace Monitoring.Dashboard.UI.Modules
{
    public class DataProviderModule : NancyModule
    {
        public DataProviderModule(ICallMonitoringService service)
        {
            //this.RequiresAnyClaim(new[] { RoleType.Admin.ToString(), RoleType.ProductManager.ToString(), RoleType.Support.ToString() });

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