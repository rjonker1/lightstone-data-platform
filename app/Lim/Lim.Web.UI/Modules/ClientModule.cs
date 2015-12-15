using DataPlatform.Shared.Enums;
using Lim.Domain.Client;
using Lim.Domain.Client.Commands;
using Lim.Domain.Client.Handlers;
using Lim.Dtos;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Security;

namespace Lim.Web.UI.Modules
{
    public class ClientModule : NancyModule
    {
        public ClientModule(IHandleGettingIntegrationClient client, IHandleSavingClient save)
        {
            this.RequiresAnyClaim(new[] { RoleType.Admin.ToString(), RoleType.ProductManager.ToString(), RoleType.Support.ToString() });

            Get["/client/new"] = _ => View["client/client", ClientDto.Create()];

            Get["/client/edit/{id}"] = _ => View["client/client", LimClient.Existing(client, new GetIntegrationClient(_.Id))];

            Post["/client/save"] = _ =>
            {
                var model = this.Bind<ClientDto>();
                save.Handle(new AddClient(model));
                return Response.AsRedirect("/client/view");
            };

            Get["/client/view"] = _ => View["client/clients", LimClient.Get(client)];
        }
    }
}