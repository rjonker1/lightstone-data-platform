using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lim.Core;
using Lim.Schedule.Core.Commands;
using Lim.Schedule.Core.Identifiers;

namespace Lim.Schedule.Core.Handlers
{
    public class HandleFetchingApiPullConfiguration : IHandleFetchingApiPullConfiguration
    {
        private static readonly ILog Log = LogManager.GetLogger<HandleFetchingApiPushConfiguration>();
        private readonly IFetch<FetchConfigurationForCustomCommand, IEnumerable<ApiPullIntegration>> _customFetcher;
        private readonly IFetch<FetchConfigurationForClientCommand, IEnumerable<ApiPullIntegration>> _clientFetcher;
        private readonly IFetch<FetchConfigurationCommand, IEnumerable<ApiPullIntegration>> _fetcher;

        public HandleFetchingApiPullConfiguration(IFetch<FetchConfigurationCommand, IEnumerable<ApiPullIntegration>> fetcher,
            IFetch<FetchConfigurationForCustomCommand, IEnumerable<ApiPullIntegration>> customFetcher,
            IFetch<FetchConfigurationForClientCommand, IEnumerable<ApiPullIntegration>> clientFetcher)
        {
            _customFetcher = customFetcher;
            _fetcher = fetcher;
            _clientFetcher = clientFetcher;
        }

        public void Handle(FetchConfigurationCommand command)
        {
            Configurations = _fetcher.Fetch(command);
            HasConfiguration = Configurations.Any();

            if (!HasConfiguration)
                Log.InfoFormat("No pull configurations found for {1} {0}", command.Action.ToString(), command.Frequency.ToString());
        }

        public void Handle(FetchConfigurationForClientCommand command)
        {
            Configurations = _clientFetcher.Fetch(command);
            HasConfiguration = Configurations.Any();
            if (!HasConfiguration)
                Log.InfoFormat("No pull client configurations found for {1} {0} on Contract {2}", command.Action.ToString(),
                    command.Frequency.ToString(), command.ContractId);
        }

        public void Handle(FetchConfigurationForCustomCommand command)
        {
            Configurations = _customFetcher.Fetch(command);
            HasConfiguration = Configurations.Any();
            if (!HasConfiguration)
                Log.InfoFormat("No custom pull configurations found for {1} {0} on {2}", command.Action.ToString(), command.Frequency.ToString(),
                    command.CustomDay);
        }

        public IEnumerable<ApiPullIntegration> Configurations { get; private set; }
        public bool HasConfiguration { get; private set; }
    }
}