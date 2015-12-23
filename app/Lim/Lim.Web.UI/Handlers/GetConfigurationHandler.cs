using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Lim.Core;
using Lim.Domain.Client.Commands;
using Lim.Domain.Client.Handlers;
using Lim.Domain.Lookup.Commands;
using Lim.Domain.Pull.Commands;
using Lim.Domain.Push.Commands;
using Lim.Domain.Push.Ftp.Commands;
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
            var dto = Mapper.Map<IEnumerable<FrequencyType>, IEnumerable<FrequencyTypeDto>>(_repository.GetAll<FrequencyType>());
            command.Set(dto);
        }

        public void Handle(GetIntegrationTypes command)
        {
            throw new NotImplementedException();
        }

        public void Handle(GetAuthenticationTypes command)
        {
            var dto = Mapper.Map<List<AuthenticationType>, List<AuthenticationTypeDto>>(_repository.GetAll<AuthenticationType>().ToList());
            command.Set(dto);
        }

        public void Handle(GetActionType command)
        {
            throw new NotImplementedException();
        }

        public void Handle(GetApiPushConfiguration command)
        {
            var configuration = _repository.Find<ConfigurationApi>(w => w.Id == command.ConfigurationId);
            var dto = Mapper.Map<ConfigurationApi, ConfigurationApiDto>(configuration);
            command.Set(dto);
        }

        public void Handle(GetFtpPushConfiguration command)
        {
            var configuration = _repository.Find<ConfigurationFtp>(w => w.Id == command.ConfigurationId);
            var dto = Mapper.Map<ConfigurationFtp, ConfigurationFtpDto>(configuration);
            command.Set(dto);
        }

        public void Handle(GetApiPullConfiguration command)
        {
            throw new NotImplementedException();
        }

        public void Handle(GetAllConfigurations command)
        {
            var dto = Mapper.Map<IEnumerable<Configuration>, IEnumerable<ConfigurationDto>>(_repository.GetAll<Configuration>());
            command.Set(dto);
        }

        public void Handle(GetWeekdays command)
        {
            command.Set(WeekdayDto.Weekdays());
        }

     
    }
}