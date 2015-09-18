using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lim.Core;
using Lim.Schedule.Core.Commands;
using Lim.Schedule.Core.Identifiers;

namespace Lim.Schedule.Core.Handlers
{
    public class HandleFetchingFlatFilePullConfiguration : IHandleFetchingFlatFilePullConfiguration
    {
        private static readonly ILog Log = LogManager.GetLogger<HandleFetchingFlatFilePullConfiguration>();
        
        private readonly IFetch<FetchConfigurationCommand, List<FlatFilePullIntegration>> _fetcher;

        public HandleFetchingFlatFilePullConfiguration(IFetch<FetchConfigurationCommand, List<FlatFilePullIntegration>> fetcher)
        {
            _fetcher = fetcher;
        }

        public void Handle(FetchConfigurationCommand command)
        {
            Configurations = _fetcher.Fetch(command);
            HasConfiguration = Configurations.Any();
        }

        public IEnumerable<FlatFilePullIntegration> Configurations { get; private set; }
        public bool HasConfiguration { get; private set; }
    }
}