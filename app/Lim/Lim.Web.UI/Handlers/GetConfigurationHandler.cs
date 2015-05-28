using System;
using Lim.Domain.Dto;
using Lim.Domain.Repository;
using Lim.Web.UI.Commands;
using Lim.Web.UI.Models.Api;

namespace Lim.Web.UI.Handlers
{
    public class GetConfigurationHandler : IHandleGettingConfiguration
    {
        private readonly IReadLimRepository _repository;

        public GetConfigurationHandler(IReadLimRepository repository)
        {
            _repository = repository;
        }

        public void Handle(GetFrequencyTypes command)
        {
            command.Set(_repository.Items<FrequencyTypeDto>(FrequencyTypeDto.Select, new {}));
        }

        public void Handle(GetIntegrationTypes command)
        {
            throw new NotImplementedException();
        }

        public void Handle(GetAuthenticationTypes command)
        {
            command.Set(_repository.Items<AuthenticationTypeDto>(AuthenticationTypeDto.Select, new {}));
        }

        public void Handle(GetActionType command)
        {
            throw new NotImplementedException();
        }

        public void Handle(GetApiPushConfiguration command)
        {
            command.Set(
                _repository.Items<PushConfigurationView>(PushConfigurationView.Select, new {@Id = command.ConfigurationId, @ClientId = command.ClientId}));
        }

        public void Handle(GetApiPullConfiguration command)
        {
            throw new NotImplementedException();
        }

        public void Handle(GetAllConfigurations command)
        {
            command.Set(_repository.Items<ConfigurationDto>(ConfigurationDto.Select, new {}));
        }

        public void Handle(GetWeekdays command)
        {
            command.Set(WeekdayDto.Weekdays());
        }
    }
}