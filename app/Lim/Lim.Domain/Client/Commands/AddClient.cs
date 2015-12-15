using Lim.Dtos;

namespace Lim.Domain.Client.Commands
{
    public class AddClient : Command
    {
        public readonly ClientDto Client;

        public AddClient(ClientDto client)
        {
            Client = client;
        }
    }
}