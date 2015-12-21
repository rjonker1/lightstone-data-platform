using System.Collections.Generic;
using System.Linq;
using Lim.Domain.Client.Commands;
using Lim.Domain.Client.Handlers;
using Lim.Dtos;

namespace Lim.Domain.Client
{
    public class FtpDatabaseConfiguration
    {
         public FtpDatabaseConfiguration()
        {

        }

         public FtpDatabaseConfiguration(ClientDto client)
        {
            Client = client;
        }

         public static List<FtpDatabaseConfiguration> Get(IHandleGettingIntegrationClient client)
        {
            var clientCommand = new GetIntegrationClients();
            client.Handle(clientCommand);
            return clientCommand.Clients.Select(s => new FtpDatabaseConfiguration(s)).ToList();
        }
        public ClientDto Client { get; private set; }
    }
}