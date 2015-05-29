using System.Collections.Generic;
using System.Linq;
using System.Net;
using Common.Logging;
using Lim.Domain.Dto;
using Lim.Domain.Repository;
using Lim.Web.UI.Commands;
using Newtonsoft.Json;

namespace Lim.Web.UI.Handlers
{
    public class GetDataPlatformClientHandler : IHandleGettingDataPlatformClient
    {
        private readonly ILog _log;
        private const string Endpoint = "/Integration/ClientCustomerContracts/All";

        public GetDataPlatformClientHandler()
        {
            _log = LogManager.GetLogger(GetType());
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
                _log.InfoFormat("Could not get a response on endpoint {0}", Endpoint);
                command.Set(Enumerable.Empty<DataPlatformClientDto>());
                return;
            }

            var dataPlatformClients = JsonConvert.DeserializeObject<IEnumerable<DataPlatformClientDto>>(clients).ToList();

            if (!dataPlatformClients.Any())
            {
                _log.InfoFormat("Could not get a deserialized list of information on endpoint {0}", Endpoint);
                command.Set(Enumerable.Empty<DataPlatformClientDto>());
                return;
            }

            command.Set(dataPlatformClients);
        }
    }

    public class GetIntegrationClientHandler : IHandleGettingIntegrationClient
    {
        private readonly IReadLimRepository _repository;

        public GetIntegrationClientHandler(IReadLimRepository repository)
        {
            _repository = repository;
        }

        public void Handle(GetIntegrationClients command)
        {
            command.Set(_repository.Items<ClientDto>(ClientDto.SelectAll, new {}));
        }

        public void Handle(GetIntegrationClient command)
        {
            command.Set(_repository.Item<ClientDto>(ClientDto.Select, new {@Id = command.Id}));
        }
    }
}