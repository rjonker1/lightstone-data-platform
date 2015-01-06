using System;
using System.Web.UI.WebControls;
using Monitoring.Read.ReadModel.Models;
using Nancy;

namespace Monitoring.Projection.UI.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ =>
            {
                var model = new MonitoringStorageModel(Guid.NewGuid());
                return View["Index", model];
            };
        }
    }
}