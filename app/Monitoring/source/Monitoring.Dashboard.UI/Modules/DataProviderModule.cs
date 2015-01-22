using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using DataPlatform.Shared.Enums;
using Monitoring.Dashboard.UI.Core.Contracts.Services;
using Monitoring.Dashboard.UI.Core.Extensions;
using Monitoring.Dashboard.UI.Core.Models;
using Nancy;
using Nancy.ModelBinding;

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
                //var model = service.GetMonitoringInformationBySource((int) MonitoringSource.Lace);
                return View["MonitoringDataProviders", new List<MonitoringResponse>()];
            };

            //Get["/dataProviders/updatedLog"] = _ =>
            //{
            //    var model = service.GetMonitoringInformationBySource((int) MonitoringSource.Lace).AsJsonString();

            //    var bytes = Encoding.UTF8.GetBytes(model);
            //    return new Response
            //    {
            //        ContentType = "application/json",
            //        Contents = s => s.Write(bytes, 0, bytes.Length)
            //    };

            //    //return Response.AsJson(model);
            //};

            Post["/dataProviders/logItem/{id}"] = _ =>
            {
                var request = this.Bind<Guid>();
                var model = service.GetMonitoringResponseItem(request, (int) MonitoringSource.Lace);
                return View["MonitoringDataProviders", model];
            };

            Get["/dataProviders/logSummary"] = _ =>
            {
                var model = service.GetMonitoringSummaryBySource((int)MonitoringSource.Lace).AsJsonString();

                var bytes = Encoding.UTF8.GetBytes(model);
                return new Response
                {
                    ContentType = "application/json",
                    Contents = s => s.Write(bytes, 0, bytes.Length)
                };

                //return Response.AsJson(model);
            };
        }
    }
}