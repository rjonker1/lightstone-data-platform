using DataPlatform.Shared.Enums;
using Lim.Domain.Dto;
using Lim.Web.UI.Commands;
using Lim.Web.UI.Handlers;
using Lim.Web.UI.Models.LimClients;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Security;

namespace Lim.Web.UI.Modules
{
    public class ClientModule : NancyModule
    {
        public ClientModule(IHandleGettingIntegrationClient client, IHandleSavingClient save)
        {
            //this.RequiresAnyClaim(new[] { RoleType.Admin.ToString(), RoleType.ProductManager.ToString(), RoleType.Support.ToString() });

            Get["/client/new"] = _ => View["client/client", ClientDto.Create()];

            Get["/client/edit/{id}"] = _ => View["client/client", LimClientView.Existing(client, new GetIntegrationClient(_.Id))];

            Post["/client/save"] = _ =>
            {
                var model = this.Bind<ClientDto>();
                save.Handle(new AddClient(model));
                return Response.AsRedirect("/client/view");
            };

            Get["/client/view"] = _ => View["client/clients", LimClientView.Get(client)];
        }
    }
}