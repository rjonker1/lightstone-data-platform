using Lim.Enums;
using Lim.Web.UI.Models;
using Lim.Web.UI.Models.Api;
using Nancy;

namespace Lim.Web.UI.Modules
{
    public class ApiModule : NancyModule
    {
        public ApiModule()
        {
            Get["/integrations/for/api/push"] = _ =>
            {
                var model = new PushConfiguration(new Configuration((int) IntegrationAction.Push, (int) IntegrationType.Api));
                model.SetClients(Client.Get());
                model.SetPackages(Package.Get());
                return View["integrations/api/push", model];
            };

            Get["/integrations/for/api/pull"] = _ =>
            {
                var model = new PullConfiguration(new Configuration((int) IntegrationAction.Pull, (int) IntegrationType.Api));
                model.SetClients(Client.Get());
                return View["integrations/api/pull", model];
            };

            Get["/integrations/for/api/configurations"] = _ =>
            {
                var model = ConfigurationView.Get();
                return View["integrations/api/configurations", model];
            };
        }
    }
}