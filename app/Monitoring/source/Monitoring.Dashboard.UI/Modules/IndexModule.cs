using System;
using Nancy;

namespace Monitoring.Dashboard.UI.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = _ =>
            {
               // var model = new MonitoringStorageModel(Guid.NewGuid());

               //  return View["Index", model];
                return null;
            };
        }
    }
}