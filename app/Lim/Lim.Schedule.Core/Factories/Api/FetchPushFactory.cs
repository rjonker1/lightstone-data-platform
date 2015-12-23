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
                var configs = _repository.Get<ConfigurationApi>(
                    w => w.Configuration.FrequencyType.Id == (int) command.Frequency && w.Configuration.ActionType.Id == (int) command.Action &&
                         w.Configuration.IntegrationType.Id == (int) command.Type && w.Configuration.IsActive).ToList();

                var configurations = AutoMapper.Mapper.Map<List<ConfigurationApi>, List<ConfigurationApiDto>>(configs);

                return Map(configurations);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An error occurred fetching configurations for API because of {0}", ex, ex.Message);
            }

            return Enumerable.Empty<ApiPushIntegration>();
        }

        private IEnumerable<ApiPushIntegration> Map(IEnumerable<ConfigurationApiDto> configs)
        {

            return configs
                .Select(s => new ApiPushIntegration(s.Configuration.ConfigurationKey, s.Id, new ApiConfigurationIdentifier(s.BaseAddress, s.Suffix,
                    new ApiAuthenticationIdentifier(s.HasAuthentication,
                        new ApiAuthenticationTypeIdentifier(s.AuthenticationType,
                            (((Enums.AuthenticationType) s.AuthenticationType)).ToString()), s.Username, s.Password,
                        s.AuthenticationKey, s.AuthenticationToken),
                    new ActionIdentifier(((Enums.IntegrationAction)s.Configuration.ActionType).ToString(), s.Configuration.ActionType),
                    new IntegrationTypeIdentifier(s.Configuration.IntegrationType, ((Enums.IntegrationAction)s.Configuration.IntegrationType).ToString()),
                    new FrequencyIdentifier(((Enums.Frequency)s.Configuration.FrequencyType).ToString(), s.Configuration.FrequencyType)),
                    new IntegrationClientIdentifier(
                        AutoMapper.Mapper.Map<IEnumerable<IntegrationClient>, IEnumerable<IntegrationClientDto>>(
                            _repository.Get<IntegrationClient>(w => w.Configuration.Id == s.Id && w.IsActive)).ToList()),
                    new IntegrationContractIdentifier(
                        AutoMapper.Mapper.Map<IEnumerable<IntegrationContract>, IEnumerable<IntegrationContractDto>>(
                            _repository.Get<IntegrationContract>(w => w.Configuration.Id == s.Id && w.IsActive)).Select(c => c.Contract)),
                    new IntegrationPackageIdentifier(
                        AutoMapper.Mapper.Map<IEnumerable<IntegrationPackage>, IEnumerable<IntegrationPackageDto>>(
                            _repository.Get<IntegrationPackage>(w => w.Configuration.Id == s.Id && w.IsActive).ToList())), new ClientIdentifier(s.Configuration.ClientId),
                    _pusher));

        }
    }
}