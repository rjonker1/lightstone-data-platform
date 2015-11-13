using Lim.Domain.Dto;
namespace Lim.Web.UI.Commands
{
    public class AddClient
    {
        public readonly ClientDto Client;

        public AddClient(ClientDto client)
        {
            Client = client;
        }
    }
}