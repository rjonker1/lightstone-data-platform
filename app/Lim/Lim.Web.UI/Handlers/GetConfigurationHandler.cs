using System;
using System.Linq;
using Lim.Domain.Dto;
using Lim.Domain.Entities;
using Lim.Domain.Entities.Repository;
using Lim.Web.UI.Commands;
using Lim.Web.UI.Models.Api;

namespace Lim.Web.UI.Handlers
{
    public class GetConfigurationHandler : IHandleGettingConfiguration
    {
        private readonly IAmRepository _repository;

        public GetConfigurationHandler(IAmRepository repository)
        {
            _repository = repository;
        }

        public void Handle(GetFrequencyTypes command)
        {
            var items = _repository.GetAll<FrequencyType>();
            var dto = items.Select(s => FrequencyTypeDto.Existing(s.Id, s.Type)).ToList();
            command.Set(dto);
        }

        public void Handle(GetIntegrationTypes command)
        {
            throw new NotImplementedException();
        }

        public void Handle(GetAuthenticationTypes command)
        {
            var items = _repository.GetAll<AuthenticationType>();
            var dto = items.Select(s => AuthenticationTypeDto.Existing(s.Id, s.Type)).ToList();
            command.Set(dto);
        }

        public void Handle(GetActionType command)
        {
            throw new NotImplementedException();
        }

        public void Handle(GetApiPushConfiguration command)
        {
            var item =
                _repository.Find<ConfigurationApi>(w => w.Configuration.Id == command.ConfigurationId && w.Configuration.Client.Id == command.ClientId);

            var packages = _repository.Get<IntegrationPackage>(w => w.IsActive && w.Configuration.Id == command.ConfigurationId);
            var clients = _repository.Get<IntegrationClient>(w => w.IsActive && w.Configuration.Id == command.ConfigurationId);
            var contracts = _repository.Get<IntegrationContract>(w => w.IsActive && w.Configuration.Id == command.ConfigurationId);

            command.Set(PushConfigurationView.Set(item.Configuration.Id, item.Id, item.Configuration.ConfigurationKey, item.Configuration.Client.Id,
                item.Configuration.Client.Name, item.Configuration.FrequencyType.Id,
                item.Configuration.ActionType.Id, item.Configuration.IntegrationType.Id, clients.Select(s => s.ClientCustomerId),
                contracts.Select(s => s.Contract), item.Configuration.DateCreated, item.Configuration.IsActive, item.BaseAddress, item.Suffix,
                item.Username, item.Password, item.HasAuthentication, item.AuthenticationToken, item.AuthenticationType.Id,
                packages.Select(s => s.PackageId), item.Configuration.CustomFrequencyTime, item.Configuration.CustomFrequencyDay));
        }

        public void Handle(GetApiPullConfiguration command)
        {
            throw new NotImplementedException();
        }

        public void Handle(GetAllConfigurations command)
        {
            var items = _repository.GetAll<Configuration>();
            var dto =
                items.Select(
                    s =>
                        ConfigurationDto.Existing(s.Id, s.ConfigurationKey, s.ActionType.Id, s.IntegrationType.Id, s.FrequencyType.Id, s.Client.Id, s.IsActive,
                            s.ActionType.Type,s.FrequencyType.Type,s.IntegrationType.Type))
                    .ToList();
            command.Set(dto);
        }

        public void Handle(GetWeekdays command)
        {
            command.Set(WeekdayDto.Weekdays());
        }
    }
}