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

        public static List<ApiConfiguration> Get(IHandleGettingConfiguration configuration,IHandleGettingClient client)
        {
            var config = new GetAllConfigurations();
            var clientCommand = new GetClients();
            configuration.Handle(config);
            client.Handle(new GetClients());
            return config.Configurations.Select(s => new ApiConfiguration(s, clientCommand.Clients.FirstOrDefault(w => w.Id == s.ClientId))).ToList();
        }

        public Configuration Configuration { get; private set; }
        public Client Client { get; private set; }
    }
}