using System.Collections.Generic;
using System.Linq;
using Lim.Domain.Client.Commands;
using Lim.Domain.Client.Handlers;
using Lim.Dtos;

namespace Lim.Domain.Client
{
    public class ApiConfiguration
    {
        public ApiConfiguration()
        {

        }

        public ApiConfiguration(ClientDto client)
        {
            Client = client;
        }

        public static List<ApiConfiguration> Get(IHandleGettingIntegrationClient client)
        {
            var clientCommand = new GetIntegrationClients();
            client.Handle(clientCommand);
            return clientCommand.Clients.Select(s => new ApiConfiguration(s)).ToList();
        }
        public ClientDto Client { get; private set; }
    }
}