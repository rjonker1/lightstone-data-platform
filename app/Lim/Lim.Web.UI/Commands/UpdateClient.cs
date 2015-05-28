using Lim.Domain.Dto;

namespace Lim.Web.UI.Commands
{
    public class UpdateClient
    {
        public readonly ClientDto Client;

        public UpdateClient(ClientDto client)
        {
            Client = client;
        }
    }
}