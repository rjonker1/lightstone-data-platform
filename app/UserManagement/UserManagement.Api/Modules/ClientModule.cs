using System.Runtime.InteropServices;
using MemBus;
using Nancy;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Clients;

namespace UserManagement.Api.Modules
{
    public class ClientModule : NancyModule
    {

        public ClientModule(IBus bus, IRepository<Client> clients)
        {

            Get["/Clients"] = _ =>
            {
                return Response.AsJson(clients);
            };

            Get["/Clients/Create"] = _ =>
            {

                bus.Publish(new CreateClient("Testeroonie Client"));

                return "Success";
            };
        }
    }
}