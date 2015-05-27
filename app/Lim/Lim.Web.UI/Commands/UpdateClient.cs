using Lim.Domain.Models;

namespace Lim.Web.UI.Commands
{
    public class UpdateClient
    {
        public readonly Client Client;

        public UpdateClient(Client client)
        {
            Client = client;
        }
    }
}