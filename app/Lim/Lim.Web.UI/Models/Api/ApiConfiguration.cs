using System.Collections.Generic;
using System.Linq;
using Lim.Web.UI.Commands;
using Lim.Web.UI.Handlers;

namespace Lim.Web.UI.Models.Api
{
    public class ApiConfiguration
    {
        public ApiConfiguration()
        {

        }

        public ApiConfiguration(Configuration configuration, Client client)
        {
            Configuration = configuration;
            Client = client;
        }

        public static List<ApiConfiguration> Get(IHandleGettingConfiguration configuration, GetAllConfigurations command,
            IHandleGettingClient client, GetClients clientCommand)
        {
            configuration.Handle(command);
            client.Handle(clientCommand);
            return command.Configurations.Select(s => new ApiConfiguration(s, clientCommand.Clients.FirstOrDefault(w => w.Id == s.ClientId))).ToList();
        }

        public Configuration Configuration { get; private set; }
        public Client Client { get; private set; }
    }
}