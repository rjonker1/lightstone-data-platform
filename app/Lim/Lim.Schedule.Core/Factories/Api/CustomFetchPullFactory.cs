﻿using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lim.Core;
using Lim.Domain.Base;
using Lim.Dtos;
using Lim.Schedule.Core.Commands;
using Lim.Schedule.Core.Identifiers;

namespace Lim.Schedule.Core.Factories.Api
{
    public class CustomFetchPullFactory : AbstractFetchFactory<FetchConfigurationForCustomCommand, IEnumerable<ApiPullIntegration>>
    {
        private readonly IRepository _repository;
        private static readonly ILog Log = LogManager.GetLogger<CustomFetchPushFactory>();

        public CustomFetchPullFactory(IRepository repository)
        {
            _repository = repository;
        }

        public override IEnumerable<ApiPullIntegration> Fetch(FetchConfigurationForCustomCommand command)
        {
            try
            {
                //TODO: No Api Pull Integrations to get
                //var configurations =
                //    _repository.Get<ConfigurationApi>(
                //        w =>
                //            w.Configuration.FrequencyType.Id == (int)command.Frequency && w.Configuration.ActionType.Id == (int)command.Action &&
                //            w.Configuration.IntegrationType.Id == (int)command.Type && w.Configuration.IsActive)
                //        .Select(
                //            s =>
                //                ApiPushConfigurationDto.Existing(s.Id, s.Configuration.ConfigurationKey, s.Configuration.FrequencyType.Id,
                //                    s.Configuration.ActionType.Id, s.Configuration.IntegrationType.Id, s.BaseAddress, s.Suffix, s.Username, s.Password,
                //                    s.AuthenticationToken, s.AuthenticationKey, s.HasAuthentication, s.AuthenticationType.Id, s.Configuration.Client.Id)).ToList();

                //return Map(configurations);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An error occurred fetching custom configurations for API because of {0}", ex, ex.Message);
            }

            return Enumerable.Empty<ApiPullIntegration>();
        }

        private IEnumerable<ApiPullIntegration> Map(IEnumerable<ApiPushConfigurationDto> configs)
        {
            return Enumerable.Empty<ApiPullIntegration>();
        }
    }
}