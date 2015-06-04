using System.Collections.Generic;
using System.Linq;
using Lim.Domain.Dto;
using Lim.Schedule.Core;
using Lim.Schedule.Core.Commands;
using Lim.Schedule.Core.Identifiers;
using Lim.Test.Helper.Mothers;

namespace Lim.Test.Helper.Fakes.Handlers
{
    public class FakeFetchingApiPushConfigurationHandler : IHandleFetchingApiPushConfiguration
    {
        public void Handle(FetchConfigurationCommand command)
        {
            var configs =
                   LimDatabase.ApiConfigurations()
                    .Where(
                       w =>
                           w.Configuration.FrequencyType.Id == (int)command.Frequency && w.Configuration.ActionType.Id == (int)command.Action &&
                           w.Configuration.IntegrationType.Id == (int)command.Type && w.Configuration.IsActive)
                       .Select(
                           s =>
                               ApiPushConfigurationDto.Existing(s.Id, s.Configuration.ConfigurationKey, s.Configuration.FrequencyType.Id,
                                   s.Configuration.ActionType.Id, s.Configuration.IntegrationType.Id, s.BaseAddress, s.Suffix, s.Username, s.Password,
                                   s.AuthenticationToken, s.AuthenticationKey, s.HasAuthentication, s.AuthenticationType.Id, s.Configuration.Client.Id)).ToList();
            HasConfiguration = configs.Any();

            SetConfigurations(configs);

        }

        public void Handle(FetchConfigurationForClientCommand command)
        {
            var configs =
                     LimDatabase.ApiConfigurations().Where(
                         w =>
                             w.Configuration.IsActive && w.Configuration.FrequencyType.Id == (int)command.Frequency && w.Configuration.ActionType.Id == (int)command.Action &&
                             w.Configuration.IntegrationType.Id == (int)command.Type)
                         .Select(
                             s =>
                                 ApiPushConfigurationDto.Existing(s.Id, s.Configuration.ConfigurationKey, s.Configuration.FrequencyType.Id,
                                     s.Configuration.ActionType.Id, s.Configuration.IntegrationType.Id, s.BaseAddress, s.Suffix, s.Username, s.Password,
                                     s.AuthenticationToken, s.AuthenticationKey, s.HasAuthentication, s.AuthenticationType.Id, s.Configuration.Client.Id)).ToList();
            HasConfiguration = configs.Any();

            Configurations = configs
                .Select(s => new ApiPushIntegration(s.Key, s.Id, new ApiConfigurationIdentifier(s.BaseAddress, s.Suffix,
                    new ApiAuthenticationIdentifier(s.HasAuthentication,
                        new ApiAuthenticationTypeIdentifier(s.AuthenticationType,
                            (((Enums.AuthenticationType)s.AuthenticationType)).ToString()), s.Username, s.Password,
                        s.AuthenticationKey, s.AuthenticationToken),
                    new IntegrationActionIdentifier(((Enums.IntegrationAction)s.Action).ToString(), s.Action),
                    new IntegrationTypeIdentifier(s.IntegrationType, ((Enums.IntegrationAction)s.IntegrationType).ToString()),
                    new IntegrationFrequencyIdentifier(((Enums.Frequency)s.FrequencyType).ToString(), s.FrequencyType)),
                    new IntegrationClientIdentifier(LimDatabase.Clients().Where(w => w.Configuration.Id == s.Id && w.IsActive)
                        .Select(
                            c =>
                                IntegrationClientDto.Existing(c.Id, c.ClientCustomerId, c.AccountNumber, c.Configuration.Id, c.IsActive,
                                    c.DateModified,
                                    c.ModifiedBy)).ToList()),
                    new IntegrationContractIdentifier(LimDatabase.Contracts().Where(
                        w => w.Configuration.Id == s.Id && w.Contract == command.ContractId && w.IsActive)
                        .Select(
                            c =>
                                IntegrationContractDto.Existing(c.Id, c.Contract, c.Configuration.Id, c.IsActive, c.DateModified, c.ModifiedBy,
                                    c.ClientCustomerId)).Select(c => c.Contract)),
                    new IntegrationPackageIdentifier(LimDatabase.Packages().Where(
                        w => w.Configuration.Id == s.Id && w.PackageId == command.PackageId && w.ContractId == command.ContractId && w.IsActive)
                        .Select(
                            p =>
                                new IntegrationPackageDto().Existing(p.Id, p.Configuration.Id, p.PackageId, p.IsActive, p.DateModified, p.ModifiedBy,
                                    p.ContractId))), new ClientIdentifier(s.ClientId)));

        }

        public void Handle(FetchConfigurationForCustomCommand command)
        {
            var configs =
                LimDatabase.ApiConfigurations()
                    .Where(
                        w =>
                            w.Configuration.IsActive && w.Configuration.FrequencyType.Id == (short) command.Frequency &&
                            w.Configuration.ActionType.Id == (short) command.Action &&
                            w.Configuration.IntegrationType.Id == (short)command.Type && w.Configuration.CustomFrequencyDay == command.CustomDay).Select(
                             s =>
                                 ApiPushConfigurationDto.Existing(s.Id, s.Configuration.ConfigurationKey, s.Configuration.FrequencyType.Id,
                                     s.Configuration.ActionType.Id, s.Configuration.IntegrationType.Id, s.BaseAddress, s.Suffix, s.Username, s.Password,
                                     s.AuthenticationToken, s.AuthenticationKey, s.HasAuthentication, s.AuthenticationType.Id, s.Configuration.Client.Id)).ToList();

            HasConfiguration = configs.Any();

            Configurations = configs
                .Select(s => new ApiPushIntegration(s.Key, s.Id, new ApiConfigurationIdentifier(s.BaseAddress, s.Suffix,
                    new ApiAuthenticationIdentifier(s.HasAuthentication,
                        new ApiAuthenticationTypeIdentifier(s.AuthenticationType,
                            (((Enums.AuthenticationType)s.AuthenticationType)).ToString()), s.Username, s.Password,
                        s.AuthenticationKey, s.AuthenticationToken),
                    new IntegrationActionIdentifier(((Enums.IntegrationAction)s.Action).ToString(), s.Action),
                    new IntegrationTypeIdentifier(s.IntegrationType, ((Enums.IntegrationAction)s.IntegrationType).ToString()),
                    new IntegrationFrequencyIdentifier(((Enums.Frequency)s.FrequencyType).ToString(), s.FrequencyType)),
                    new IntegrationClientIdentifier(LimDatabase.Clients().Where(w => w.Configuration.Id == s.Id && w.IsActive)
                        .Select(
                            c =>
                                IntegrationClientDto.Existing(c.Id, c.ClientCustomerId, c.AccountNumber, c.Configuration.Id, c.IsActive,
                                    c.DateModified,
                                    c.ModifiedBy)).ToList()),
                    new IntegrationContractIdentifier(LimDatabase.Contracts().Where(w => w.Configuration.Id == s.Id && w.IsActive)
                        .Select(
                            c =>
                                IntegrationContractDto.Existing(c.Id, c.Contract, c.Configuration.Id, c.IsActive, c.DateModified, c.ModifiedBy,
                                    c.ClientCustomerId)).Select(c => c.Contract)),
                    new IntegrationPackageIdentifier(LimDatabase.Packages().Where(w => w.Configuration.Id == s.Id && w.IsActive)
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
                            (((Enums.AuthenticationType)s.AuthenticationType)).ToString()), s.Username, s.Password,
                        s.AuthenticationKey, s.AuthenticationToken),
                    new IntegrationActionIdentifier(((Enums.IntegrationAction)s.Action).ToString(), s.Action),
                    new IntegrationTypeIdentifier(s.IntegrationType, ((Enums.IntegrationAction)s.IntegrationType).ToString()),
                    new IntegrationFrequencyIdentifier(((Enums.Frequency)s.FrequencyType).ToString(), s.FrequencyType)),
                    new IntegrationClientIdentifier(LimDatabase.Clients().Where(w => w.Configuration.Id == s.Id && w.IsActive)
                        .Select(
                            c =>
                                IntegrationClientDto.Existing(c.Id, c.ClientCustomerId, c.AccountNumber, c.Configuration.Id, c.IsActive,
                                    c.DateModified,
                                    c.ModifiedBy)).ToList()),
                    new IntegrationContractIdentifier(LimDatabase.Contracts().Where(w => w.Configuration.Id == s.Id && w.IsActive)
                        .Select(
                            c =>
                                IntegrationContractDto.Existing(c.Id, c.Contract, c.Configuration.Id, c.IsActive, c.DateModified, c.ModifiedBy,
                                    c.ClientCustomerId)).Select(c => c.Contract)),
                    new IntegrationPackageIdentifier(LimDatabase.Packages().Where(w => w.Configuration.Id == s.Id && w.IsActive)
                        .Select(
                            p =>
                                new IntegrationPackageDto().Existing(p.Id, p.Configuration.Id, p.PackageId, p.IsActive, p.DateModified, p.ModifiedBy,
                                    p.ContractId))), new ClientIdentifier(s.ClientId)));

        }

        public bool HasConfiguration { get; private set; }
        public IEnumerable<ApiPushIntegration> Configurations { get; private set; }
    }
}
