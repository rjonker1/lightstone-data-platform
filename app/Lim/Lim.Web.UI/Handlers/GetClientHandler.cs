﻿using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lim.Core;
using Lim.Domain.Dto;
using Lim.Domain.Entities;
using Lim.Domain.Entities.Repository;
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
        private readonly IRepository _repository;

        public GetIntegrationClientHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(GetIntegrationClients command)
        {
            var items = _repository.GetAll<Client>();
            var dto =
                items.Select(
                    s => ClientDto.Existing(s.Id, s.IsActive, s.Name, s.Email, s.ContactPerson, s.ContactNumber, s.ModifiedBy, s.DateModified)).ToList();
            command.Set(dto.Any() ? dto : Enumerable.Empty<ClientDto>());
        }

        public void Handle(GetIntegrationClient command)
        {
            var item = _repository.Get<Client>(w => w.Id == command.Id);
            var dto = item.Select(
                s => ClientDto.Existing(s.Id, s.IsActive, s.Name, s.Email, s.ContactPerson, s.ContactNumber, s.ModifiedBy, s.DateModified)).FirstOrDefault();
            command.Set(dto);
        }
    }
}