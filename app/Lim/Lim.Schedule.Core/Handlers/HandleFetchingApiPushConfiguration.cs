using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lim.Core;
using Lim.Schedule.Core.Commands;
using Lim.Schedule.Core.Identifiers;

namespace Lim.Schedule.Core.Handlers
{
    public class HandleFetchingApiPushConfiguration : IHandleFetchingApiPushConfiguration
    {
        private static readonly ILog Log = LogManager.GetLogger<HandleFetchingApiPushConfiguration>();
        private readonly IFetch<FetchConfigurationForCustomCommand, IEnumerable<ApiPushIntegration>> _customFetcher;
        private readonly IFetch<FetchConfigurationForClientCommand, IEnumerable<ApiPushIntegration>> _clientFetcher;
        private readonly IFetch<FetchConfigurationCommand, IEnumerable<ApiPushIntegration>> _fetcher;

        public HandleFetchingApiPushConfiguration(IFetch<FetchConfigurationCommand, IEnumerable<ApiPushIntegration>> fetcher,
            IFetch<FetchConfigurationForCustomCommand, IEnumerable<ApiPushIntegration>> customFetcher,
            IFetch<FetchConfigurationForClientCommand, IEnumerable<ApiPushIntegration>> clientFetcher)
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
                Log.InfoFormat("No configurations found for {1} {0}", command.Action.ToString(), command.Frequency.ToString());
        }

        public void Handle(FetchConfigurationForCustomCommand command)
        {
            Configurations = _customFetcher.Fetch(command);
            HasConfiguration = Configurations.Any();
            if (!HasConfiguration)
                Log.InfoFormat("No custom push configurations found for {1} {0} on {2}", command.Action.ToString(), command.Frequency.ToString(),
                    command.CustomDay);
        }

        public void Handle(FetchConfigurationForClientCommand command)
        {
            Configurations = _clientFetcher.Fetch(command);
            HasConfiguration = Configurations.Any();
            if (!HasConfiguration)
                Log.InfoFormat("No client configurations found for {1} {0} on Contract {2}", command.Action.ToString(),
                    command.Frequency.ToString(), command.ContractId);

        }

        public IEnumerable<ApiPushIntegration> Configurations { get; private set; }
        public bool HasConfiguration { get; private set; }
    }
}