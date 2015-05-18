using System.Collections.Generic;
using Lim.Web.UI.Models;

namespace Lim.Web.UI.Commands
{
    public class GetClients
    {
        public void Set(IEnumerable<Client> clients)
        {
            Clients = clients;
        }

        public IEnumerable<Client> Clients { get; private set; }
    }
}