using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lim.Domain.Models;
using Lim.Domain.Repository;
using Lim.Schedule.Core.Commands;
using Lim.Schedule.Core.Identifiers;

namespace Lim.Schedule.Core.Handlers
{
    public class HandleFetchingApiPushConfiguration : IHandleFetchingApiPushConfiguration
    {
        private readonly ILimRepository _repository;
        private readonly ILog _log;

        public HandleFetchingApiPushConfiguration(ILimRepository repository)
        {
            _repository = repository;
            _log = LogManager.GetLogger(GetType());
        }

        public void Handle(FetchConfigurationCommand command)
        {
            try
            {
                var configs =
                    _repository.Items<ApiPushConfiguration>(ApiPushConfiguration.Select,
                        new {@FrequencyType = (int) command.Frequency, @Action = (int) command.Action, @IntegrationType = (int) command.Type})
                        .ToList();
                _log.InfoFormat("{0} {1} Api Configurations will be handled", configs.Count(), command.Frequency.ToString());

                HasConfiguration = configs.Any();

                if (!HasConfiguration)
                {
                    _log.InfoFormat("No configurations found for {1} {0}", command.Action.ToString(), command.Frequency.ToString());
                    return;
                }

                Configurations = configs
                .Select(s => new ApiPushIntegration(s.Key,s.Id, new ApiConfigurationIdentifier(s.BaseAddress, s.Suffix,
                    new ApiAuthenticationIdentifier(s.HasAuthentication,
                        new ApiAuthenticationTypeIdentifier(s.AuthenticationType,
                            (((Enums.AuthenticationType) s.AuthenticationType)).ToString()), s.Username, s.Password,
                        s.AuthenticationKey, s.AuthenticationToken),
                    new IntegrationActionIdentifier(((Enums.IntegrationAction) s.Action).ToString()),
                    new IntegrationTypeIdentifier(s.IntegrationType, ((Enums.IntegrationAction) s.IntegrationType).ToString())),
                    new IntegrationClientIdentifier(_repository.Items<IntegrationClient>(IntegrationClient.Select, new { @ConfigurationId = s.Id})),
                    new IntegrationContractIdentifier(_repository.Items<IntegrationContract>(IntegrationContract.Select, new { @ConfigurationId = s.Id }).Select(c =>c.Contract)),
                    new IntegrationPackageIdentifier(_repository.Items<IntegrationPackage>(IntegrationPackage.Select, new { @ConfigurationId = s.Id })), new ClientIdentifier(s.ClientId)));
            

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
                    _repository.Items<ApiPushConfiguration>(ApiPushConfiguration.SelectWithCustomDay,
                        new
                        {
                            @FrequencyType = (int) command.Frequency,
                            @Action = (int) command.Action,
                            @IntegrationType = (int) command.Type,
                            @CustomFrequencyDay = command.CustomDay
                        })
                        .ToList();
                _log.InfoFormat("{0} {1} Api Custom Push Configurations on {2} will be handled", configs.Count(), command.Frequency.ToString(),
                    command.CustomDay);

                HasConfiguration = configs.Any();

                if (!HasConfiguration)
                {
                    _log.InfoFormat("No custom push configurations found for {1} {0} on {2}", command.Action.ToString(), command.Frequency.ToString(),
                        command.CustomDay);
                    return;
                }

                Configurations = configs
                 .Select(s => new ApiPushIntegration(s.Key, s.Id, new ApiConfigurationIdentifier(s.BaseAddress, s.Suffix,
                     new ApiAuthenticationIdentifier(s.HasAuthentication,
                         new ApiAuthenticationTypeIdentifier(s.AuthenticationType,
                             (((Enums.AuthenticationType)s.AuthenticationType)).ToString()), s.Username, s.Password,
                         s.AuthenticationKey, s.AuthenticationToken),
                     new IntegrationActionIdentifier(((Enums.IntegrationAction)s.Action).ToString()),
                     new IntegrationTypeIdentifier(s.IntegrationType, ((Enums.IntegrationAction)s.IntegrationType).ToString())),
                     new IntegrationClientIdentifier(_repository.Items<IntegrationClient>(IntegrationClient.Select, new { @ConfigurationId = s.Id })),
                     new IntegrationContractIdentifier(_repository.Items<IntegrationContract>(IntegrationContract.Select, new { @ConfigurationId = s.Id }).Select(c => c.Contract)),
                     new IntegrationPackageIdentifier(_repository.Items<IntegrationPackage>(IntegrationPackage.Select, new { @ConfigurationId = s.Id })), new ClientIdentifier(s.ClientId)));

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
                    _repository.Items<ApiPushConfiguration>(ApiPushConfiguration.Select,
                        new
                        {
                            @FrequencyType = (int) command.Frequency,
                            @Action = (int) command.Action,
                            @IntegrationType = (int) command.Type
                        }).ToList();
                _log.InfoFormat("{0} {1} Api Configurations for specific client and contract will be handled", configs.Count(),
                    command.Frequency.ToString());

                HasConfiguration = configs.Any();

                if (!HasConfiguration)
                {
                    _log.InfoFormat("No client configurations found for {1} {0} on Contract {2}", command.Action.ToString(),
                        command.Frequency.ToString(), command.ContractId);
                    return;
                }

                Configurations = configs
                .Select(s => new ApiPushIntegration(s.Key, s.Id, new ApiConfigurationIdentifier(s.BaseAddress, s.Suffix,
                    new ApiAuthenticationIdentifier(s.HasAuthentication,
                        new ApiAuthenticationTypeIdentifier(s.AuthenticationType,
                            (((Enums.AuthenticationType)s.AuthenticationType)).ToString()), s.Username, s.Password,
                        s.AuthenticationKey, s.AuthenticationToken),
                    new IntegrationActionIdentifier(((Enums.IntegrationAction)s.Action).ToString()),
                    new IntegrationTypeIdentifier(s.IntegrationType, ((Enums.IntegrationAction)s.IntegrationType).ToString())),
                    new IntegrationClientIdentifier(_repository.Items<IntegrationClient>(IntegrationClient.Select, new { @ConfigurationId = s.Id })),
                    new IntegrationContractIdentifier(_repository.Items<IntegrationContract>(IntegrationContract.SelectContract, new { @ConfigurationId = s.Id, @ContractId = command.ContractId }).Select(c => c.Contract)),
                    new IntegrationPackageIdentifier(_repository.Items<IntegrationPackage>(IntegrationPackage.SelectPackage, new { @ConfigurationId = s.Id, @PackageId = command.PackageId })), new ClientIdentifier(s.ClientId)));
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("An error occurred handling client configurations because of {0}", ex, ex.Message);
            }
        }
        public IEnumerable<ApiPushIntegration> Configurations { get; private set; }
        public bool HasConfiguration { get; private set; }
    }
}