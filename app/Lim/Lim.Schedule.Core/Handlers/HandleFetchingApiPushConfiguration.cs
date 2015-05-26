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

                Configurations = configs.GroupBy(g => new
                {
                    Key = g,
                    Contracts =  g,
                    Packages = g.PackageId,
                    Clients = g.ClientId,
                    //Accounts = g.AccountNumber
                })
                .Distinct()
                .Select(s => new ApiPushIntegration(s.Key.Key.Key,s.Key.Key.Id, new ApiConfigurationIdentifier(s.Key.Key.BaseAddress, s.Key.Key.Suffix,
                    new ApiAuthenticationIdentifier(s.Key.Key.HasAuthentication,
                        new ApiAuthenticationTypeIdentifier(s.Key.Key.AuthenticationType,
                            (((Enums.AuthenticationType) s.Key.Key.AuthenticationType)).ToString()), s.Key.Key.Username, s.Key.Key.Password,
                        s.Key.Key.AuthenticationKey, s.Key.Key.AuthenticationToken),
                    new IntegrationActionIdentifier(((Enums.IntegrationAction) s.Key.Key.Action).ToString()),
                    new IntegrationTypeIdentifier(s.Key.Key.IntegrationType, ((Enums.IntegrationAction) s.Key.Key.IntegrationType).ToString())),
                    new IntegrationClientIdentifier(s.Distinct().Select(c => new ClientAccount(c.ClientCustomerId, c.AccountNumber))),
                    new IntegrationContractIdentifier(s.Distinct().Select(c => c.Contract)), 
                    new IntegrationPackageIdentifier(s.Distinct().Select(p => new PackageContract(p.PackageId,p.Contract))), new ClientIdentifier(s.Key.Key.ClientId)));

                //Configurations = configs.GroupBy(g => g, g => g.PackageId,  (key, packages) => new
                //{
                //    Key = key,
                //    Packages = packages,
                //    Clients = key.ClientCustomerId

                //}).Select(s => new ApiPushIntegration(s.Key.Key, new ApiConfigurationIdentifier(s.Key.BaseAddress, s.Key.Suffix,
                //    new ApiAuthenticationIdentifier(s.Key.HasAuthentication,
                //        new ApiAuthenticationTypeIdentifier(s.Key.AuthenticationType,
                //            (((Enums.AuthenticationType) s.Key.AuthenticationType)).ToString()), s.Key.Username, s.Key.Password,
                //        s.Key.AuthenticationKey, s.Key.AuthenticationToken),
                //    new IntegrationActionIdentifier(((Enums.IntegrationAction) s.Key.Action).ToString()),
                //    new IntegrationTypeIdentifier(s.Key.IntegrationType, ((Enums.IntegrationAction) s.Key.IntegrationType).ToString())),
                //    new IntegrationClientIdentifier(s.Key.ClientCustomerId, s.Key.AccountNumber),
                //    new IntegrationContractIdentifier(s.Contracts.), 
                //    new IntegrationPackageIdentifier(s.Packages.Select(p => p)), new ClientIdentifier(s.Key.ClientId)));

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

                Configurations = configs.GroupBy(g => new
                {
                    Key = g
                })
                .Select(s => new ApiPushIntegration(s.Key.Key.Key,s.Key.Key.Id, new ApiConfigurationIdentifier(s.Key.Key.BaseAddress, s.Key.Key.Suffix,
                    new ApiAuthenticationIdentifier(s.Key.Key.HasAuthentication,
                        new ApiAuthenticationTypeIdentifier(s.Key.Key.AuthenticationType,
                            (((Enums.AuthenticationType)s.Key.Key.AuthenticationType)).ToString()), s.Key.Key.Username, s.Key.Key.Password,
                        s.Key.Key.AuthenticationKey, s.Key.Key.AuthenticationToken),
                    new IntegrationActionIdentifier(((Enums.IntegrationAction)s.Key.Key.Action).ToString()),
                    new IntegrationTypeIdentifier(s.Key.Key.IntegrationType, ((Enums.IntegrationAction)s.Key.Key.IntegrationType).ToString())),
                    new IntegrationClientIdentifier(s.Select(c => new ClientAccount(c.ClientCustomerId, c.AccountNumber))),
                    new IntegrationContractIdentifier(s.Select(c => c.Contract)),
                    new IntegrationPackageIdentifier(s.Select(p => new PackageContract(p.PackageId, p.Contract))), new ClientIdentifier(s.Key.Key.ClientId)));

                //Configurations = configs.GroupBy(g => g, g => g.PackageId, (key, packages) => new
                //{
                //    Key = key,
                //    Packages = packages

                //}).Select(s => new ApiPushIntegration(s.Key.Key, new ApiConfigurationIdentifier(s.Key.BaseAddress, s.Key.Suffix,
                //    new ApiAuthenticationIdentifier(s.Key.HasAuthentication,
                //        new ApiAuthenticationTypeIdentifier(s.Key.AuthenticationType,
                //            (((Enums.AuthenticationType) s.Key.AuthenticationType)).ToString()), s.Key.Username, s.Key.Password,
                //        s.Key.AuthenticationKey, s.Key.AuthenticationToken),
                //    new IntegrationActionIdentifier(((Enums.IntegrationAction) s.Key.Action).ToString()),
                //    new IntegrationTypeIdentifier(s.Key.IntegrationType, ((Enums.IntegrationAction) s.Key.IntegrationType).ToString())),
                //    new IntegrationClientIdentifier(s.Key.ClientCustomerId, s.Key.AccountNumber),
                //    new IntegrationContractIdentifier(s.Key.Contract),
                //    new IntegrationPackageIdentifier(s.Packages.Select(p => p)), new ClientIdentifier(s.Key.ClientId)));

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
                    _repository.Items<ApiPushConfiguration>(ApiPushConfiguration.SelectWithContract,
                        new
                        {
                            @FrequencyType = (int) command.Frequency,
                            @Action = (int) command.Action,
                            @IntegrationType = (int) command.Type,
                            @ContractId = command.ContractId,
                            @PackageId = command.PackageId
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

                Configurations = configs.GroupBy(g => new
                {
                    Key = g
                })
                .Select(s => new ApiPushIntegration(s.Key.Key.Key,s.Key.Key.Id, new ApiConfigurationIdentifier(s.Key.Key.BaseAddress, s.Key.Key.Suffix,
                    new ApiAuthenticationIdentifier(s.Key.Key.HasAuthentication,
                        new ApiAuthenticationTypeIdentifier(s.Key.Key.AuthenticationType,
                            (((Enums.AuthenticationType)s.Key.Key.AuthenticationType)).ToString()), s.Key.Key.Username, s.Key.Key.Password,
                        s.Key.Key.AuthenticationKey, s.Key.Key.AuthenticationToken),
                    new IntegrationActionIdentifier(((Enums.IntegrationAction)s.Key.Key.Action).ToString()),
                    new IntegrationTypeIdentifier(s.Key.Key.IntegrationType, ((Enums.IntegrationAction)s.Key.Key.IntegrationType).ToString())),
                    new IntegrationClientIdentifier(s.Select(c => new ClientAccount(c.ClientCustomerId, c.AccountNumber))),
                    new IntegrationContractIdentifier(s.Select(c => c.Contract)),
                    new IntegrationPackageIdentifier(s.Select(p => new PackageContract(p.PackageId, p.Contract))), new ClientIdentifier(s.Key.Key.ClientId)));

                //Configurations = configs.GroupBy(g => g, g => g.PackageId, (key, packages) => new
                //{
                //    Key = key,
                //    Packages = packages

                //}).Select(s => new ApiPushIntegration(s.Key.Key, new ApiConfigurationIdentifier(s.Key.BaseAddress, s.Key.Suffix,
                //    new ApiAuthenticationIdentifier(s.Key.HasAuthentication,
                //        new ApiAuthenticationTypeIdentifier(s.Key.AuthenticationType,
                //            (((Enums.AuthenticationType) s.Key.AuthenticationType)).ToString()), s.Key.Username, s.Key.Password,
                //        s.Key.AuthenticationKey, s.Key.AuthenticationToken),
                //    new IntegrationActionIdentifier(((Enums.IntegrationAction) s.Key.Action).ToString()),
                //    new IntegrationTypeIdentifier(s.Key.IntegrationType, ((Enums.IntegrationAction) s.Key.IntegrationType).ToString())),
                //    new IntegrationClientIdentifier(s.Key.ClientCustomerId, s.Key.AccountNumber),
                //    new IntegrationContractIdentifier(s.Key.Contract), 
                //    new IntegrationPackageIdentifier(s.Packages.Select(p => p)),new ClientIdentifier(s.Key.ClientId)));

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