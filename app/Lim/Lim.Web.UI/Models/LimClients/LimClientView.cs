using System.Collections.Generic;
using System.Linq;
using Lim.Domain.Dto;
using Lim.Web.UI.Commands;
using Lim.Web.UI.Handlers;

namespace Lim.Web.UI.Models.LimClients
{
    public class LimClientView
    {
        public readonly ClientDto Client;
        public LimClientView(ClientDto client)
        {
            Client = client;
        }

        public static IEnumerable<LimClientView> Get(IHandleGettingIntegrationClient client)
        {
            var command = new GetIntegrationClients();
            client.Handle(command);
            return command.Clients.Select(s => new LimClientView(s));
        }

        public static ClientDto Existing(IHandleGettingIntegrationClient client, GetIntegrationClient command)
        {
            client.Handle(command);
            return command.Client;
        }
    }
}