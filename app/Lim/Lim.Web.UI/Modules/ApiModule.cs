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
        public ApiModule(IHandleGettingClient client, IHandleGettingConfiguration setup, IHandleSavingConfiguration save)
        {
            Get["/integrations/for/api/push"] = _ =>
            {
                var model = PushConfiguration.Create();
                model.SetClients(client, new GetClients());
                model.SetPackages(client, new GetClientPackages(new Guid()));
                model.SetFrequency(setup, new GetFrequencyTypes());
                model.SetAuthentication(setup, new GetAuthenticationTypes());
                model.SetContracts(client, new GetClientContracts(new Guid()));
                return View["integrations/api/push", model];
            };

            Get["/integrations/for/api/push/edit/{id}/{clientId}"] = _ =>
            {
                int id;
                Guid clientId;

                int.TryParse(_.Id, out id);
                Guid.TryParse(_.clientId, out clientId);

                if (id == 0 || clientId == Guid.Empty)
                    return HttpStatusCode.NoResponse;

                var model = PushConfiguration.Existing(setup, new GetApiPushConfiguration(id, clientId));
                model.SetClients(client, new GetClients());
                model.SetPackages(client, new GetClientPackages(clientId));
                model.SetFrequency(setup, new GetFrequencyTypes());
                model.SetAuthentication(setup, new GetAuthenticationTypes());
                model.SetContracts(client, new GetClientContracts(clientId));
                return View["integrations/api/push", model];
            };

            Post["/integrations/for/api/push/save"] = _ =>
            {
                var configuration = this.Bind<PushConfiguration>();
                var command = new InsertApiPushConfiguration(configuration.SplitAccountAndClientId());
                save.Handle(command);
                return save.IsSaved ? Negotiate.WithView("/integrations/for/api/configurations") : View["integrations/api/push", configuration];
            };

            Get["/integrations/for/api/pull"] = _ =>
            {
                var model = new PullConfiguration(new Configuration((int) IntegrationAction.Pull, (int) IntegrationType.Api));
                model.SetClients(client, new GetClients());
                return View["integrations/api/pull", model];
            };

            Get["/integrations/for/api/configurations"] = _ =>
            {
                var model = ApiConfiguration.Get(setup, new GetAllConfigurations(), client, new GetClients());
                return View["integrations/api/configurations", model];
            };
        }
    }
}