using System;
using System.Collections.Generic;
using System.Linq;
using Lim.Core;
using Lim.Domain.Client.Commands;
using Lim.Domain.Client.Handlers;
using Lim.Domain.Lookup.Commands;
using Lim.Domain.Pull.Commands;
using Lim.Domain.Push;
using Lim.Domain.Push.Commands;
using Lim.Dtos;
using Lim.Entities;

namespace Lim.Web.UI.Handlers
{
    public class GetConfigurationHandler : IHandleGettingConfiguration
    {
        private readonly IRepository _repository;

        public GetConfigurationHandler(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(GetFrequencyTypes command)
        {
            var dto = AutoMapper.Mapper.Map<IEnumerable<FrequencyType>, IEnumerable<FrequencyTypeDto>>(_repository.GetAll<FrequencyType>());
            command.Set(dto);
        }

        public void Handle(GetIntegrationTypes command)
        {
            throw new NotImplementedException();
        }

        public void Handle(GetAuthenticationTypes command)
        {
            var dto = AutoMapper.Mapper.Map<List<AuthenticationType>, List<AuthenticationTypeDto>>(_repository.GetAll<AuthenticationType>().ToList());
            command.Set(dto);
        }

        public void Handle(GetActionType command)
        {
            throw new NotImplementedException();
        }

        public void Handle(GetApiPushConfiguration command)
        {
            var dto = AutoMapper.Mapper.Map<Client, ClientDto>(_repository.Find<Client>(w => w.Id == command.ClientId));
            var configuration = dto.Configurations.FirstOrDefault(w => w.Id == command.ConfigurationId) ?? new ConfigurationDto();
            var item = _repository.Find<ConfigurationApi>(w => w.Id == command.ConfigurationId);

            command.Set(PushConfigurationView.Set(configuration.Id, item.Id, configuration.ConfigurationKey, dto.Id,
                dto.Name, configuration.FrequencyType,
                configuration.ActionType, configuration.IntegrationType, configuration.IntegrationClients.Select(s => s.ClientCustomerId),
                configuration.IntegrationContracts.Select(s => s.Contract), dto.DateCreated, dto.IsActive, item.BaseAddress, item.Suffix,
                item.Username, item.Password, item.HasAuthentication,item.AuthenticationKey, item.AuthenticationToken, item.AuthenticationType.Id,
                configuration.IntegrationPackages.Select(s => s.PackageId), configuration.CustomFrequencyTime, configuration.CustomFrequencyDay));
        }

        public void Handle(GetApiPullConfiguration command)
        {
            throw new NotImplementedException();
        }

        public void Handle(GetAllConfigurations command)
        {
            var dto = AutoMapper.Mapper.Map<IEnumerable<Configuration>, IEnumerable<ConfigurationDto>>(_repository.GetAll<Configuration>());
            command.Set(dto);
        }

        public void Handle(GetWeekdays command)
        {
            command.Set(WeekdayDto.Weekdays());
        }
    }
}