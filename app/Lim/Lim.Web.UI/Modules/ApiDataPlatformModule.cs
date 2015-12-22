using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lim.Domain.Client;
using Lim.Domain.Client.Commands;
using Lim.Domain.Client.Handlers;
using Lim.Domain.Lookup.Commands;
using Lim.Domain.Pull;
using Lim.Domain.Push;
using Lim.Domain.Push.Commands;
using Lim.Dtos;
using Lim.Web.UI.Commands;
using Lim.Web.UI.Handlers;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Security;
using Shared.BuildingBlocks.Api.ApiClients;

namespace Lim.Web.UI.Modules
{
    public class ApiDataPlatformModule : NancyModule
    {
        private static List<DataPlatformClientDto> GetDataPlatformClients(IHandleGettingDataPlatformClient dataPlatform, IUserManagementApiClient api,
            string token)
        {
            var command = new GetDataPlatformClients(api, token);
            dataPlatform.Handle(command);
            return command.Clients.Any() ? command.Clients.ToList() : new List<DataPlatformClientDto>();
        }


        public ApiDataPlatformModule(IHandleGettingConfiguration setup, IHandleSavingConfiguration save, IHandleGettingIntegrationClient client,
            IUserManagementApiClient api, IHandleGettingDataPlatformClient dataPlatform, IHandleGettingMetadata metadata)
        {
            this.RequiresAnyClaim(new[] { RoleType.Admin.ToString(), RoleType.ProductManager.ToString(), RoleType.Support.ToString() });

            Get["/integrations/for/api/push"] = _ =>
            {
                var model = PushApiDataPlatformConfiguration.Create();
                var token = Context.Request.Headers.Authorization.Any() ? Context.Request.Headers.Authorization.Split(' ')[1] : string.Empty;
                model.SetFrequency(setup, new GetFrequencyTypes());
                model.SetAuthentication(setup, new GetAuthenticationTypes());
             
                model.SetDataPlatformClients(GetDataPlatformClients(dataPlatform, api,token));

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

                    if (id == 0 || clientId == 0) return HttpStatusCode.BadRequest;

                    var token = Context.Request.Headers.Authorization.Any() ? Context.Request.Headers.Authorization.Split(' ')[1] : string.Empty;
                    var model = PushApiDataPlatformConfiguration.Existing(setup, new GetApiPushConfiguration(id, clientId));
                    model.SetFrequency(setup, new GetFrequencyTypes());
                    model.SetAuthentication(setup, new GetAuthenticationTypes());
                    model.SetDataPlatformClients(GetDataPlatformClients(dataPlatform, api, token));
                    model.SetWeekdays(setup, new GetWeekdays());
                    model.SetIntegrationClients(client, new GetIntegrationClients());
                    return View["integrations/api/push", model];
                };

            Post["/integrations/for/api/push/save"] = _ =>
            {
                var configuration = this.Bind<PushApiDataPlatformConfiguration>();
                var token = Context.Request.Headers.Authorization.Any() ? Context.Request.Headers.Authorization.Split(' ')[1] : string.Empty;
                configuration.SetDataPlatformClients(GetDataPlatformClients(dataPlatform, api, token));
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

            Get["/integrations/for/api/configurations"] = _ => View["integrations/api/configurations", ApiConfiguration.Get(client)];

            Get["/integrations/for/api/metadata/push"] = _ =>
            {
                var command = new GetApiResponseMetadataCommand();
                metadata.Handle(command);
                return View["integrations/api/pushmetadata", command.Metadata];
            };
        }
    }
}