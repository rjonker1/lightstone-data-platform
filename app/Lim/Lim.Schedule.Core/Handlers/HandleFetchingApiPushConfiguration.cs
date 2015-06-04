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
    public class HandleFetchingApiPushConfiguration : IHandleFetchingApiPushConfiguration
    {
        private readonly IAmRepository _repository;
        private readonly ILog _log;

        public HandleFetchingApiPushConfiguration(IAmRepository repository)
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
                            w.Configuration.FrequencyType.Id == (int) command.Frequency && w.Configuration.ActionType.Id == (int) command.Action &&
                            w.Configuration.IntegrationType.Id == (int) command.Type && w.Configuration.IsActive)
                        .Select(
                            s =>
                                ApiPushConfigurationDto.Existing(s.Id, s.Configuration.ConfigurationKey, s.Configuration.FrequencyType.Id,
                                    s.Configuration.ActionType.Id, s.Configuration.IntegrationType.Id, s.BaseAddress, s.Suffix, s.Username, s.Password,
                                    s.AuthenticationToken, s.AuthenticationKey, s.HasAuthentication, s.AuthenticationType.Id, s.Configuration.Client.Id)).ToList();
             
                _log.InfoFormat("{0} {1} Api Configurations will be handled", configs.Count(), command.Frequency.ToString());

                HasConfiguration = configs.Any();

                if (!HasConfiguration)
                {
                    _log.InfoFormat("No configurations found for {1} {0}", command.Action.ToString(), command.Frequency.ToString());
                    return;
                }

                SetConfigurations(configs);

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("An error occurred handling configurations because of {0}", ex, ex.Message);
            }
        }

        public void Handle(FetchConfigurationForCustomCommand command)
        {
            try
            {
                var configs =
                    _repository.Get<ConfigurationApi>(
                        w =>
                            w.Configuration.IsActive && w.Configuration.FrequencyType.Id == (short)command.Frequency && w.Configuration.ActionType.Id == (short)command.Action &&
                            w.Configuration.IntegrationType.Id == (short)command.Type && w.Configuration.CustomFrequencyDay == command.CustomDay &&
                            w.Configuration.CustomFrequencyTime >= DateTime.Now.AddMinutes(-1).TimeOfDay && w.Configuration.CustomFrequencyTime <= DateTime.Now.AddMinutes(1).TimeOfDay)
                        .Select(
                            s =>
                                ApiPushConfigurationDto.Existing(s.Id, s.Configuration.ConfigurationKey, s.Configuration.FrequencyType.Id,
                                    s.Configuration.ActionType.Id, s.Configuration.IntegrationType.Id, s.BaseAddress, s.Suffix, s.Username, s.Password,
                                    s.AuthenticationToken, s.AuthenticationKey, s.HasAuthentication, s.AuthenticationType.Id, s.Configuration.Client.Id)).ToList();
               
                _log.InfoFormat("{0} {1} Api Custom Push Configurations on {2} will be handled", configs.Count(), command.Frequency.ToString(),
                    command.CustomDay);

                HasConfiguration = configs.Any();

                if (!HasConfiguration)
                {
                    _log.InfoFormat("No custom push configurations found for {1} {0} on {2}", command.Action.ToString(), command.Frequency.ToString(),
                        command.CustomDay);
                    return;
                }

                SetConfigurations(configs);
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
                             w.Configuration.IsActive && w.Configuration.FrequencyType.Id == (int)command.Frequency && w.Configuration.ActionType.Id == (int)command.Action &&
                             w.Configuration.IntegrationType.Id == (int)command.Type)
                         .Select(
                             s =>
                                 ApiPushConfigurationDto.Existing(s.Id, s.Configuration.ConfigurationKey, s.Configuration.FrequencyType.Id,
                                     s.Configuration.ActionType.Id, s.Configuration.IntegrationType.Id, s.BaseAddress, s.Suffix, s.Username, s.Password,
                                     s.AuthenticationToken, s.AuthenticationKey, s.HasAuthentication, s.AuthenticationType.Id, s.Configuration.Client.Id)).ToList();

                _log.InfoFormat("{0} {1} Api Configurations for specific client and contract will be handled", configs.Count(),
                    command.Frequency.ToString());

                HasConfiguration = configs.Any();

                if (!HasConfiguration)
                {
                    _log.InfoFormat("No client configurations found for {1} {0} on Contract {2}", command.Action.ToString(),
                        command.Frequency.ToString(), command.ContractId);
                    return;
                }

                SetConfigurations(configs, command.ContractId, command.PackageId);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("An error occurred handling client configurations because of {0}", ex, ex.Message);
            }
        }

        private void SetConfigurations(IEnumerable<ApiPushConfigurationDto> configs, Guid contractId, Guid packageId)
        {
            Configurations = configs
                .Select(s => new ApiPushIntegration(s.Key, s.Id, new ApiConfigurationIdentifier(s.BaseAddress, s.Suffix,
                    new ApiAuthenticationIdentifier(s.HasAuthentication,
                        new ApiAuthenticationTypeIdentifier(s.AuthenticationType,
                            (((Enums.AuthenticationType) s.AuthenticationType)).ToString()), s.Username, s.Password,
                        s.AuthenticationKey, s.AuthenticationToken),
                    new IntegrationActionIdentifier(((Enums.IntegrationAction)s.Action).ToString(), s.Action),
                    new IntegrationTypeIdentifier(s.IntegrationType, ((Enums.IntegrationAction) s.IntegrationType).ToString()),
                    new IntegrationFrequencyIdentifier(((Enums.Frequency)s.FrequencyType).ToString(),s.FrequencyType)),
                    new IntegrationClientIdentifier(_repository.Get<IntegrationClient>(w => w.Configuration.Id == s.Id && w.IsActive)
                        .Select(
                            c =>
                                IntegrationClientDto.Existing(c.Id, c.ClientCustomerId, c.AccountNumber, c.Configuration.Id, c.IsActive,
                                    c.DateModified,
                                    c.ModifiedBy)).ToList()),
                    new IntegrationContractIdentifier(_repository.Get<IntegrationContract>(
                        w => w.Configuration.Id == s.Id && w.Contract == contractId && w.IsActive)
                        .Select(
                            c =>
                                IntegrationContractDto.Existing(c.Id, c.Contract, c.Configuration.Id, c.IsActive, c.DateModified, c.ModifiedBy,
                                    c.ClientCustomerId)).Select(c => c.Contract)),
                    new IntegrationPackageIdentifier(_repository.Get<IntegrationPackage>(
                        w => w.Configuration.Id == s.Id && w.PackageId == packageId && w.ContractId == contractId && w.IsActive)
                        .Select(
                            p =>
                                new IntegrationPackageDto().Existing(p.Id, p.Configuration.Id, p.PackageId, p.IsActive, p.DateModified, p.ModifiedBy,
                                    p.ContractId))), new ClientIdentifier(s.ClientId)));

        }

        private void SetConfigurations(IEnumerable<ApiPushConfigurationDto> configs)
        {
            Configurations = configs
                .Select(s => new ApiPushIntegration(s.Key, s.Id, new ApiConfigurationIdentifier(s.BaseAddress, s.Suffix,
                    new ApiAuthenticationIdentifier(s.HasAuthentication,
                        new ApiAuthenticationTypeIdentifier(s.AuthenticationType,
                            (((Enums.AuthenticationType) s.AuthenticationType)).ToString()), s.Username, s.Password,
                        s.AuthenticationKey, s.AuthenticationToken),
                    new IntegrationActionIdentifier(((Enums.IntegrationAction) s.Action).ToString(),s.Action),
                    new IntegrationTypeIdentifier(s.IntegrationType, ((Enums.IntegrationAction) s.IntegrationType).ToString()),
                    new IntegrationFrequencyIdentifier(((Enums.Frequency)s.FrequencyType).ToString(),s.FrequencyType)),
                    new IntegrationClientIdentifier(_repository.Get<IntegrationClient>(w => w.Configuration.Id == s.Id && w.IsActive)
                        .Select(
                            c =>
                                IntegrationClientDto.Existing(c.Id, c.ClientCustomerId, c.AccountNumber, c.Configuration.Id, c.IsActive,
                                    c.DateModified,
                                    c.ModifiedBy)).ToList()),
                    new IntegrationContractIdentifier(_repository.Get<IntegrationContract>(w => w.Configuration.Id == s.Id && w.IsActive)
                        .Select(
                            c =>
                                IntegrationContractDto.Existing(c.Id, c.Contract, c.Configuration.Id, c.IsActive, c.DateModified, c.ModifiedBy,
                                    c.ClientCustomerId)).Select(c => c.Contract)),
                    new IntegrationPackageIdentifier(_repository.Get<IntegrationPackage>(w => w.Configuration.Id == s.Id && w.IsActive)
                        .Select(
                            p =>
                                new IntegrationPackageDto().Existing(p.Id, p.Configuration.Id, p.PackageId, p.IsActive, p.DateModified, p.ModifiedBy,
                                    p.ContractId))), new ClientIdentifier(s.ClientId)));

        }


        public IEnumerable<ApiPushIntegration> Configurations { get; private set; }
        public bool HasConfiguration { get; private set; }
    }
}