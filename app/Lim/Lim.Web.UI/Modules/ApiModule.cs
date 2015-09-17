using System.Linq;
using DataPlatform.Shared.Enums;
using Lim.Web.UI.Commands;
using Lim.Web.UI.Handlers;
using Lim.Web.UI.Models.Api;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Security;
using Shared.BuildingBlocks.Api.ApiClients;

namespace Lim.Web.UI.Modules
{
    public class ApiModule : NancyModule
    {
        public ApiModule(IHandleGettingConfiguration setup, IHandleSavingConfiguration save, IHandleGettingIntegrationClient client,
            IUserManagementApiClient api, IHandleGettingDataPlatformClient dataPlatform, IHandleGettingMetadata metadata)
        {
            this.RequiresAnyClaim(new[] { RoleType.Admin.ToString(), RoleType.ProductManager.ToString(), RoleType.Support.ToString() });

            Get["/integrations/for/api/push"] = _ =>
            {
                var model = PushConfiguration.Create();
                var token = Context.Request.Headers.Authorization.Any() ? Context.Request.Headers.Authorization.Split(' ')[1] : string.Empty;
                model.SetFrequency(setup, new GetFrequencyTypes());
                model.SetAuthentication(setup, new GetAuthenticationTypes());
                model.SetDataPlatformClients(dataPlatform, new GetDataPlatformClients(api, token));
                model.SetWeekdays(setup, new GetWeekdays());
                model.SetIntegrationClients(client, new GetIntegrationClients());
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

                    var token = Context.Request.Headers.Authorization.Any() ? Context.Request.Headers.Authorization.Split(' ')[1] : string.Empty;
                    var model = PushConfiguration.Existing(setup, new GetApiPushConfiguration(id, clientId));
                    model.SetFrequency(setup, new GetFrequencyTypes());
                    model.SetAuthentication(setup, new GetAuthenticationTypes());
                    model.SetDataPlatformClients(dataPlatform, new GetDataPlatformClients(api, token));
                    model.SetWeekdays(setup, new GetWeekdays());
                    model.SetIntegrationClients(client, new GetIntegrationClients());
                    return View["integrations/api/push", model];
                };

            Post["/integrations/for/api/push/save"] = _ =>
            {
                var configuration = this.Bind<PushConfiguration>();
                var token = Context.Request.Headers.Authorization.Any() ? Context.Request.Headers.Authorization.Split(' ')[1] : string.Empty;
                configuration.SetDataPlatformClients(dataPlatform, new GetDataPlatformClients(api, token));
                var command = new AddApiPushConfiguration(configuration);
                save.Handle(command);
                return Response.AsRedirect("/integrations/for/api/configurations");
            };

            Get["/integrations/for/api/pull"] = _ =>
            {
                var model = PullConfiguration.Create();
                model.SetAuthentication(setup);
                model.SetFrequency(setup);
                model.SetWeekdays(setup, new GetWeekdays());
                model.SetIntegrationClients(client, new GetIntegrationClients());
                return View["integrations/api/pull", model];
            };

            Get["/integrations/for/api/configurations"] = _ => View["integrations/api/configurations", ApiConfiguration.Get(setup, client)];

            Get["/integrations/for/api/metadata/push"] = _ =>
            {
                var command = new GetApiResponseMetadataCommand();
                metadata.Handle(command);
                return View["integrations/api/pushmetadata", command.Metadata];
            };
        }
    }
}