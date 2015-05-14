using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lim.Domain.Respository;
using Lim.Fake.Database;
using Nancy;

namespace Lim.Web.UI.Modules
{
    public class ClientModule : NancyModule
    {
        public ClientModule()
        {
            Get["/Client/{filter}"] = _ =>
            {
                var details = new FakeLimRepo().Contracts.ToList().Where(w => w.ClientName == _.filter);
                return Response.AsJson(details.Select(s => new ClientDto(s.ClientId, s.ClientName)));
            };
        }
    }

    public class ClientDto
    {
        public ClientDto(Guid id, string name)
        {
            ClientId = id;
            Name = name;
        }
        public Guid ClientId { get; private set; }
        public string Name { get; private set; }
    }
}