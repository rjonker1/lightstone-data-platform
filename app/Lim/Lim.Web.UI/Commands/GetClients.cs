using System;
using System.Collections.Generic;
using System.Web.Configuration;
using Lim.Domain.Models;

namespace Lim.Web.UI.Commands
{
    public class GetDataPlatformClients
    {
        public void Set(IEnumerable<DataPlatformClient> clients)
        {
            Clients = clients;
        }
       
       public IEnumerable<DataPlatformClient> Clients { get; private set; }
    }

    public class GetIntegrationClients
    {
        public void Set(IEnumerable<Client> clients)
        {
            Clients = clients;
        }

        public IEnumerable<Client> Clients { get; private set; }
    }

    public class GetIntegrationClient
    {
        public readonly long Id;

        public GetIntegrationClient(long id)
        {
            Id = id;
        }

        public void Set(Client client)
        {
            Client = client;
        }

        public Client Client { get; private set; }
    }
}