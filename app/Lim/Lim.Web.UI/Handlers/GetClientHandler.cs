using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lim.Dtos;
using Lim.Web.UI.Commands;
using Newtonsoft.Json;

namespace Lim.Web.UI.Handlers
{
    public class GetDataPlatformClientHandler : IHandleGettingDataPlatformClient
    {
        private static readonly ILog Log = LogManager.GetLogger<GetDataPlatformClientHandler>();
        private const string Endpoint = "/Integration/ClientCustomerContracts/All";

        public GetDataPlatformClientHandler()
        {
        }

        public void Handle(GetDataPlatformClients command)
        {
            var authorization = new[]
            {
                new KeyValuePair<string, string>("Authorization", "Token " + command.Token),
                new KeyValuePair<string, string>("Content-Type", "application/json")
            };

            var clients = command.Api.Get("", Endpoint);

            if (string.IsNullOrEmpty(clients))
            {
                Log.InfoFormat("Could not get a response on endpoint {0}", Endpoint);
                command.Set(Enumerable.Empty<DataPlatformClientDto>());
                return;
            }

            var dataPlatformClients = JsonConvert.DeserializeObject<IEnumerable<DataPlatformClientDto>>(clients).ToList();

            if (!dataPlatformClients.Any())
            {
                Log.InfoFormat("Could not get a deserialized list of information on endpoint {0}", Endpoint);
                command.Set(Enumerable.Empty<DataPlatformClientDto>());
                return;
            }

            command.Set(dataPlatformClients);
        }
    }

    
}