using System.Collections.Generic;
using System.Linq;
using Lim.Domain.Client.Commands;
using Lim.Domain.Client.Handlers;
using Lim.Dtos;

namespace Lim.Domain.Client
{
    public class LimClient
    {
        public readonly ClientDto Client;
        public LimClient(ClientDto client)
        {
            Client = client;
        }

        public static IEnumerable<LimClient> Get(IHandleGettingIntegrationClient client)
        {
            var command = new GetIntegrationClients();
            client.Handle(command);
            return command.Clients.Select(s => new LimClient(s));
        }

        public static ClientDto Existing(IHandleGettingIntegrationClient client, GetIntegrationClient command)
        {
            client.Handle(command);
            return command.Client;
        }
    }
}