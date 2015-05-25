using Lim.Domain.Models;
using Lim.Web.UI.Handlers;
using Nancy;
using Nancy.ModelBinding;

namespace Lim.Web.UI.Modules
{
    public class ClientModule : NancyModule
    {
        public ClientModule(IHandleGettingIntegrationClient client)
        {
            Get["/client/new"] = _ =>
            {
                var model = Client.Create();
                return View["clients/client", model];
            };

            Get["client/edit/{id}"] = _ =>
            {
                var model = Client.Existing(_.Id);
                return View["clients/client", model];
            };

            Post["/client/save"] = _ =>
            {
                var model = this.Bind<Client>();
                //TOOO: Save the client
                return Response.AsRedirect("/clients/clients");
            };

            Get["client/view/all"] = _ =>
            {
                var model = Client.Get();
                return View["/clients/clients", model];
            };
        }
    }
}