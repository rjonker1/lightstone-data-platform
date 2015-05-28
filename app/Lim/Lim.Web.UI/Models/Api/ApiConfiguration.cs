using System.Collections.Generic;
using System.Linq;
using Lim.Domain.Dto;
using Lim.Web.UI.Commands;
using Lim.Web.UI.Handlers;

namespace Lim.Web.UI.Models.Api
{
    public class ApiConfiguration
    {
        public ApiConfiguration()
        {

        }

        public ApiConfiguration(ConfigurationDto configuration, ClientDto client)
        {
            Configuration = configuration;
            Client = client;
        }

        public static List<ApiConfiguration> Get(IHandleGettingConfiguration configuration, IHandleGettingIntegrationClient client)
        {
            var config = new GetAllConfigurations();
            var clientCommand = new GetIntegrationClients();
            configuration.Handle(config);
            client.Handle(clientCommand);
            return config.Configurations.Select(s => new ApiConfiguration(s, clientCommand.Clients.FirstOrDefault(w => w.Id == s.ClientId))).ToList();
        }

        public ConfigurationDto Configuration { get; private set; }
        public ClientDto Client { get; private set; }
    }
}