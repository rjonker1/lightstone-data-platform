using Lim.Domain.Models;

namespace Lim.Web.UI.Commands
{
    public class AddClient
    {
        public readonly Client Client;

        public AddClient(Client client)
        {
            Client = client;
        }
    }
}