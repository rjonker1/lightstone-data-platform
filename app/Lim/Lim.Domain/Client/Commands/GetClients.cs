using System.Collections.Generic;
using Lim.Dtos;

namespace Lim.Domain.Client.Commands
{
    public class GetIntegrationClients : Command
    {
        public void Set(IEnumerable<ClientDto> clients)
        {
            Clients = clients;
        }

        public IEnumerable<ClientDto> Clients { get; private set; }
    }

    public class GetIntegrationClient : Command
    {
        public readonly long Id;

        public GetIntegrationClient(long id)
        {
            Id = id;
        }

        public void Set(ClientDto client)
        {
            Client = client;
        }

        public ClientDto Client { get; private set; }
    }
}