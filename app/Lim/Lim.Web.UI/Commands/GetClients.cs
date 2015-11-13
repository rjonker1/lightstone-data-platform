using System.Collections.Generic;
using Lim.Domain.Dto;
using Shared.BuildingBlocks.Api.ApiClients;

namespace Lim.Web.UI.Commands
{
    public class GetDataPlatformClients
    {
        public readonly IUserManagementApiClient Api;
        public readonly string Token;

        public GetDataPlatformClients(IUserManagementApiClient api, string token)
        {
            Api = api;
            Token = token;
        }

        public void Set(IEnumerable<DataPlatformClientDto> clients)
        {
            Clients = clients;
        }

        public IEnumerable<DataPlatformClientDto> Clients { get; private set; }
    }

    public class GetIntegrationClients
    {
        public void Set(IEnumerable<ClientDto> clients)
        {
            Clients = clients;
        }

        public IEnumerable<ClientDto> Clients { get; private set; }
    }

    public class GetIntegrationClient
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