using Lim.Domain.Dto;
using Lim.Web.UI.Commands;
using Lim.Web.UI.Handlers;
using Lim.Web.UI.Models.LimClients;
using Nancy;
using Nancy.ModelBinding;

namespace Lim.Web.UI.Modules
{
    public class ClientModule : NancyModule
    {
        public ClientModule(IHandleGettingIntegrationClient client, IHandleSavingClient save)
        {
            Get["/client/new"] = _ =>
            {
                var model = ClientDto.Create();
                return View["clients/client", model];
            };

            Get["client/edit/{id}"] = _ =>
            {
                var model = LimClientView.Existing(client, new GetIntegrationClient(_.Id));
                return View["clients/client", model];
            };

            Post["/client/save"] = _ =>
            {
                var model = this.Bind<ClientDto>();
                save.Handle(new AddClient(model));
                return Response.AsRedirect("/client/view/all");
            };

            Get["client/view/all"] = _ =>
            {
                var model = LimClientView.Get(client);
                return View["/clients/clients", model];
            };
        }
    }
}