using System;
using Lim.Enums;
using Lim.Web.UI.Commands;
using Lim.Web.UI.Handlers;
using Lim.Web.UI.Models;
using Lim.Web.UI.Models.Api;
using Nancy;
using Nancy.ModelBinding;

namespace Lim.Web.UI.Modules
{
    public class ApiModule : NancyModule
    {
        public ApiModule(IHandleGettingClient clientHandler, IHandleGettingConfiguration configurationHandler, IHandleSavingConfiguration configurationSave)
        {
            Get["/integrations/for/api/push"] = _ =>
            {
                var model = PushConfiguration.Create();
                model.SetClients(clientHandler, new GetClients());
                model.SetPackages(clientHandler, new GetClientPackages(new Guid()));
                model.SetFrequency(configurationHandler,new GetFrequencyTypes());
                model.SetAuthentication(configurationHandler,new GetAuthenticationTypes());
                model.SetContracts(clientHandler,new GetClientContracts(new Guid()));
                return View["integrations/api/push", model];
            };

            Post["/integrations/for/api/push/save"] = _ =>
            {
                var configuration = this.Bind<PushConfiguration>();
                var command = new InsertApiPushConfiguration(configuration.SplitAccountAndClientId());
                configurationSave.Handle(command);
                return HttpStatusCode.OK;
            };

            Get["/integrations/for/api/pull"] = _ =>
            {
                var model = new PullConfiguration(new Configuration((int) IntegrationAction.Pull, (int) IntegrationType.Api));
                model.SetClients(clientHandler, new GetClients());
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