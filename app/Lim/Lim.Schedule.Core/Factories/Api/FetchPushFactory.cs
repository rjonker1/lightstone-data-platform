using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lim.Core;
using Lim.Domain.Base;
using Lim.Dtos;
using Lim.Entities;
using Lim.Schedule.Core.Commands;
using Lim.Schedule.Core.Identifiers;

namespace Lim.Schedule.Core.Factories.Api
{
    public class FetchPushFactory : AbstractFetchFactory<FetchConfigurationCommand, IEnumerable<ApiPushIntegration>>
    {
        private static readonly ILog Log = LogManager.GetLogger<FetchPushFactory>();
        private readonly IRepository _repository;
        private readonly IPush<ApiInitializePushCommand> _pusher;

        public FetchPushFactory(IRepository repository, IPush<ApiInitializePushCommand> pusher)
        {
            _repository = repository;
            _pusher = pusher;
        }

        public override IEnumerable<ApiPushIntegration> Fetch(FetchConfigurationCommand command)
        {
            try
            {
                var configurations = AutoMapper.Mapper.Map<IEnumerable<ConfigurationApi>, IEnumerable<ApiPushConfigurationDto>>(
                    _repository.Get<ConfigurationApi>(
                        w => w.Configuration.FrequencyType.Id == (int) command.Frequency && w.Configuration.ActionType.Id == (int) command.Action &&
                             w.Configuration.IntegrationType.Id == (int)command.Type && w.Configuration.IsActive).ToList());

                return Map(configurations);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An error occurred fetching configurations for API because of {0}", ex, ex.Message);
            }

            return Enumerable.Empty<ApiPushIntegration>();
        }

        private IEnumerable<ApiPushIntegration> Map(IEnumerable<ApiPushConfigurationDto> configs)
        {

            return configs
                .Select(s => new ApiPushIntegration(s.Key, s.Id, new ApiConfigurationIdentifier(s.BaseAddress, s.Suffix,
                    new ApiAuthenticationIdentifier(s.HasAuthentication,
                        new ApiAuthenticationTypeIdentifier(s.AuthenticationType,
                            (((Enums.AuthenticationType) s.AuthenticationType)).ToString()), s.Username, s.Password,
                        s.AuthenticationKey, s.AuthenticationToken),
                    new ActionIdentifier(((Enums.IntegrationAction) s.Action).ToString(), s.Action),
                    new IntegrationTypeIdentifier(s.IntegrationType, ((Enums.IntegrationAction) s.IntegrationType).ToString()),
                    new FrequencyIdentifier(((Enums.Frequency) s.FrequencyType).ToString(), s.FrequencyType)),
                    new IntegrationClientIdentifier(
                        AutoMapper.Mapper.Map<IEnumerable<IntegrationClient>, IEnumerable<IntegrationClientDto>>(
                            _repository.Get<IntegrationClient>(w => w.Configuration.Id == s.Id && w.IsActive)).ToList()),
                    new IntegrationContractIdentifier(
                        AutoMapper.Mapper.Map<IEnumerable<IntegrationContract>, IEnumerable<IntegrationContractDto>>(
                            _repository.Get<IntegrationContract>(w => w.Configuration.Id == s.Id && w.IsActive)).Select(c => c.Contract)),
                    new IntegrationPackageIdentifier(
                        AutoMapper.Mapper.Map<IEnumerable<IntegrationPackage>, IEnumerable<IntegrationPackageDto>>(
                            _repository.Get<IntegrationPackage>(w => w.Configuration.Id == s.Id && w.IsActive).ToList())), new ClientIdentifier(s.ClientId),
                    _pusher));

        }
    }
}