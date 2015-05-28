using System;
using Lim.Web.UI.Commands;
using Lim.Web.UI.Handlers;
using Lim.Web.UI.Models.Api;
using Nancy;
using Nancy.ModelBinding;

namespace Lim.Web.UI.Modules
{
    public class ApiModule : NancyModule
    {
        public ApiModule(IHandleGettingDataPlatformClient dataPlatformClient, IHandleGettingConfiguration setup, IHandleSavingConfiguration save, IHandleGettingIntegrationClient client)
        {
            Get["/integrations/for/api/push"] = _ =>
            {
                var model = PushConfiguration.Create();
                model.SetDataPlatformClients(dataPlatformClient, new GetDataPlatformClients());
                model.SetDataPlatformPackages(dataPlatformClient, new GetDataPlatformClientPackages(new Guid()));
                model.SetFrequency(setup, new GetFrequencyTypes());
                model.SetAuthentication(setup, new GetAuthenticationTypes());
                model.SetDataPlatformContracts(dataPlatformClient, new GetDataPlatformClientContracts(new Guid()));
                model.SetWeekdays(setup, new GetWeekdays());
                model.SetIntegrationClients(client,new GetIntegrationClients());
                return View["integrations/api/push", model];
            };

            Get["/integrations/for/api/push/edit/{id}/{clientId}"] = _ =>
            {
                int id;
                int clientId;

                int.TryParse(_.Id, out id);
                int.TryParse(_.clientId, out clientId);

                if (id == 0 || clientId == 0)
                    return HttpStatusCode.NoResponse;

                var model = PushConfiguration.Existing(setup, new GetApiPushConfiguration(id, clientId));
                model.SetDataPlatformClients(dataPlatformClient, new GetDataPlatformClients());
                model.SetDataPlatformPackages(dataPlatformClient, new GetDataPlatformClientPackages(new Guid()));
                model.SetFrequency(setup, new GetFrequencyTypes());
                model.SetAuthentication(setup, new GetAuthenticationTypes());
                model.SetDataPlatformContracts(dataPlatformClient, new GetDataPlatformClientContracts(new Guid()));
                model.SetWeekdays(setup, new GetWeekdays());
                model.SetIntegrationClients(client,new GetIntegrationClients());
                return View["integrations/api/push", model];
            };

            Post["/integrations/for/api/push/save"] = _ =>
            {
                var configuration = this.Bind<PushConfiguration>();
                configuration.SetDataPlatformPackages(dataPlatformClient, new GetDataPlatformClientPackages(new Guid()));
                configuration.SetDataPlatformContracts(dataPlatformClient, new GetDataPlatformClientContracts(new Guid()));
                var command = new AddApiPushConfiguration(configuration);
                save.Handle(command);
                //return save.IsSaved ? Response.AsRedirect("/") : View["integrations/api/push", configuration];
                return Response.AsRedirect("/integrations/for/api/configurations");
            };

            Get["/integrations/for/api/pull"] = _ =>
            {
                var model = PullConfiguration.Create();
                model.SetClients(dataPlatformClient);
                model.SetAuthentication(setup);
                model.SetFrequency(setup);
                model.SetContracts(dataPlatformClient,new GetDataPlatformClientContracts(Guid.NewGuid()));
                model.SetWeekdays(setup, new GetWeekdays());
                model.SetIntegrationClients(client,new GetIntegrationClients());
                return View["integrations/api/pull", model];
            };

            Get["/integrations/for/api/configurations"] = _ =>
            {
                var model = ApiConfiguration.Get(setup, client);
                return View["integrations/api/configurations", model];
            };
        }
    }
}