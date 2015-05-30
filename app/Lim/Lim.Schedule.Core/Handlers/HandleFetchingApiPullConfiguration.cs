using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lim.Domain.Dto;
using Lim.Domain.Entities;
using Lim.Domain.Entities.Repository;
using Lim.Schedule.Core.Commands;
using Lim.Schedule.Core.Identifiers;

namespace Lim.Schedule.Core.Handlers
{
    public class HandleFetchingApiPullConfiguration : IHandleFetchingApiPullConfiguration
    {
        private readonly IAmRepository _repository;
        private readonly ILog _log;

        public HandleFetchingApiPullConfiguration(IAmRepository repository)
        {
            _repository = repository;
            _log = LogManager.GetLogger(GetType());
        }

        public void Handle(FetchConfigurationCommand command)
        {
            try
            {
                var configs =
                   _repository.Get<ConfigurationApi>(
                       w =>
                           w.Configuration.FrequencyType.Id == (int)command.Frequency && w.Configuration.ActionType.Id == (int)command.Action &&
                           w.Configuration.IntegrationType.Id == (int)command.Type)
                       .Select(
                           s =>
                               ApiPullConfigurationDto.Existing(s.Id, s.Configuration.ConfigurationKey, s.Configuration.FrequencyType.Id,
                                   s.Configuration.ActionType.Id, s.Configuration.IntegrationType.Id, s.BaseAddress, s.Suffix, s.Username, s.Password,
                                   s.AuthenticationToken, s.AuthenticationKey, s.HasAuthentication, s.AuthenticationType.Id, s.Configuration.Client.Id)).ToList();

                _log.InfoFormat("{0} Api Pull Configurations will be handled", configs.Count());

                HasConfiguration = configs.Any();

                if (!HasConfiguration)
                {
                    _log.InfoFormat("No configurations found for API {0}", command.Action.ToString());
                    return;
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("An error occurred handling configurations because of {0}", ex, ex.Message);
            }
        }

        public void Handle(FetchConfigurationForClientCommand command)
        {
            try
            {
                var configs =
                     _repository.Get<ConfigurationApi>(
                         w =>
                             w.Configuration.FrequencyType.Id == (int)command.Frequency && w.Configuration.ActionType.Id == (int)command.Action &&
                             w.Configuration.IntegrationType.Id == (int)command.Type)
                         .Select(
                             s =>
                                 ApiPullConfigurationDto.Existing(s.Id, s.Configuration.ConfigurationKey, s.Configuration.FrequencyType.Id,
                                     s.Configuration.ActionType.Id, s.Configuration.IntegrationType.Id, s.BaseAddress, s.Suffix, s.Username, s.Password,
                                     s.AuthenticationToken, s.AuthenticationKey, s.HasAuthentication, s.AuthenticationType.Id, s.Configuration.Client.Id)).ToList();


                _log.InfoFormat("{0} Api Pull Configurations for specific client and contract will be handled", configs.Count());

                HasConfiguration = configs.Any();

                if (!HasConfiguration)
                {
                    _log.InfoFormat("No client configurations found for {1} {0} on Contract {2}", command.Action.ToString(),
                       command.Frequency.ToString(), command.ContractId);
                    return;
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("An error occurred handling client configurations because of {0}", ex, ex.Message);
            }
        }

        public void Handle(FetchConfigurationForCustomCommand command)
        {
            try
            {
                var configs =
                   _repository.Get<ConfigurationApi>(
                       w =>
                           w.Configuration.FrequencyType.Id == (short)command.Frequency && w.Configuration.ActionType.Id == (short)command.Action &&
                           w.Configuration.IntegrationType.Id == (short)command.Type && w.Configuration.CustomFrequencyDay == command.CustomDay &&
                           w.Configuration.CustomFrequencyTime >= DateTime.Now.AddMinutes(-1).TimeOfDay && w.Configuration.CustomFrequencyTime <= DateTime.Now.AddMinutes(1).TimeOfDay)
                       .Select(
                           s =>
                               ApiPullConfigurationDto.Existing(s.Id, s.Configuration.ConfigurationKey, s.Configuration.FrequencyType.Id,
                                   s.Configuration.ActionType.Id, s.Configuration.IntegrationType.Id, s.BaseAddress, s.Suffix, s.Username, s.Password,
                                   s.AuthenticationToken, s.AuthenticationKey, s.HasAuthentication, s.AuthenticationType.Id, s.Configuration.Client.Id)).ToList();

                _log.InfoFormat("{0} {1} Api Custom Pull Configurations on {2} will be handled", configs.Count(), command.Frequency.ToString(), command.CustomDay);

                HasConfiguration = configs.Any();

                if (!HasConfiguration)
                {
                    _log.InfoFormat("No custom pull configurations found for {1} {0} on {2}", command.Action.ToString(), command.Frequency.ToString(), command.CustomDay);
                    return;
                }
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("An error occurred handling configurations because of {0}", ex, ex.Message);
            }
        }

        public IEnumerable<ApiPullIntegration> Configurations { get; private set; }
        public bool HasConfiguration { get; private set; }
    }
}