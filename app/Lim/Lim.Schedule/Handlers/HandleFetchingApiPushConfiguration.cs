using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lim.Domain.Models;
using Lim.Domain.Repository;
using Lim.Schedule.Commands;
using Lim.Schedule.Core;
using Lim.Schedule.Indentifiers;

namespace Lim.Schedule.Handlers
{
    public class HandleFetchingApiPushConfiguration : IHandleFetchingApiPushConfiguration
    {
        private readonly IRepository _repository;
        private readonly ILog _log;

        public HandleFetchingApiPushConfiguration(IRepository repository)
        {
            _repository = repository;
            _log = LogManager.GetLogger(GetType());
        }

        public void Handle(FetchConfigurationCommand command)
        {
            try
            {
                var configs = _repository.Get<ApiPushConfiguration>(ApiPushConfiguration.Select, new { @FrequencyType = (int)command.Frequency, @Action = (int)command.Action, @IntegrationType = (int)command.Type }).ToList();
                _log.InfoFormat("{0} {1} Api Configurations will be handled", configs.Count(), command.Frequency.ToString());

                HasConfiguration = configs.Any();

                if (!HasConfiguration)
                {
                    _log.InfoFormat("No configurations found for {1} {0}", command.Action.ToString(), command.Frequency.ToString());
                    return;
                }

                Configurations = configs.GroupBy(g => g, g => g.PackageId, (key, packages) => new
                {
                    Key = key,
                    Packages = packages

                }).Select(s => new ApiPushIntegration(s.Key.Key, new ApiConfigurationIdentifier(s.Key.BaseAddress, s.Key.Suffix,
                    new ApiAuthenticationIdentifier(s.Key.HasAuthentication,
                        new ApiAuthenticationTypeIdentifier(s.Key.AuthenticationType,(((Enums.AuthenticationType) s.Key.AuthenticationType)).ToString()),s.Key.Username, s.Key.Password,s.Key.AuthenticationKey,s.Key.AuthenticationToken),
                    new IntegrationActionIdentifier(((Enums.IntegrationAction)s.Key.Action).ToString()),
                    new IntegrationTypeIdentifier(s.Key.IntegrationType, ((Enums.IntegrationAction)s.Key.IntegrationType).ToString())),
                    new IntegrationClientIdentifier(s.Key.ClientId, s.Key.AccountNumber),
                    new IntegrationPackageIdentifier(s.Packages.Select(p => p))));

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("An error occurred handling configurations because of {0}", ex, ex.Message);
            }

        }

        public IEnumerable<ApiPushIntegration> Configurations { get; private set; }
        public bool HasConfiguration { get; private set; }
    }
}