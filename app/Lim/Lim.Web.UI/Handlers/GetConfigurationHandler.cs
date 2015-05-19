﻿using System;
using System.Linq;
using Lim.Web.UI.Commands;
using Lim.Web.UI.Models;
using Lim.Web.UI.Models.Api;
using Lim.Web.UI.Repository;

namespace Lim.Web.UI.Handlers
{
    public class GetConfigurationHandler : IHandleGettingConfiguration
    {
        private readonly ILimRepository _repository;

        public GetConfigurationHandler(ILimRepository repository)
        {
            _repository = repository;
        }

        public void Handle(GetFrequencyTypes command)
        {
            command.Set(_repository.Items<FrequencyType>(FrequencyType.Select, new {}));
        }

        public void Handle(GetIntegrationTypes command)
        {
            throw new NotImplementedException();
        }

        public void Handle(GetAuthenticationTypes command)
        {
            command.Set(_repository.Items<AuthenticationType>(AuthenticationType.Select, new {}));
        }

        public void Handle(GetActionType command)
        {
            throw new NotImplementedException();
        }

        public void Handle(GetApiPushConfiguration command)
        {
            command.Set(
                _repository.Items<PushConfigurationView>(PushConfigurationView.Select, new {@Id = command.ConfigurationId}).FirstOrDefault());
        }

        public void Handle(GetApiPullConfiguration command)
        {
            throw new NotImplementedException();
        }
    }
}