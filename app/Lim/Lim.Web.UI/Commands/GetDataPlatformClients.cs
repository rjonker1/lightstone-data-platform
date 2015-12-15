using System.Collections.Generic;
using Lim.Dtos;
using Shared.BuildingBlocks.Api.ApiClients;

namespace Lim.Web.UI.Commands
{
    public class GetDataPlatformClients : Command
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
}