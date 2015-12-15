using Lim.Dtos;

namespace Lim.Domain.Client.Commands
{
    public class UpdateClient : Command
    {
        public readonly ClientDto Client;

        public UpdateClient(ClientDto client)
        {
            Client = client;
        }
    }
}