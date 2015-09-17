using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lim.Infrastructure;
using Lim.Schedule.Core.Commands;
using Lim.Schedule.Core.Identifiers;
using Toolbox.Bmw.Finance;

namespace Lim.Schedule.Core.Handlers
{
    public class HandleFetchingFlatFilePullConfiguration : IHandleFetchingFlatFilePullConfiguration
    {
        private static readonly ILog Log = LogManager.GetLogger<HandleFetchingFlatFilePullConfiguration>();

        public HandleFetchingFlatFilePullConfiguration()
        {
            
        }

        public void Handle(FetchConfigurationForAlwaysOnCommand command)
        {
            //TODO: This needs to read from the database. Its like this for now to get to work for LIVE 1.0
            Configurations = new List<FlatFilePullIntegration>()
            {
                new FlatFilePullIntegration(Guid.NewGuid(),
                    new FlatFileIndentifier(ConfigurationReader.Bmw.FilePath, ConfigurationReader.Bmw.FileName,
                        ConfigurationReader.Bmw.FirstRowIsColumnName, ConfigurationReader.Bmw.FilePassword, true,
                        ConfigurationReader.Bmw.FileExtension),
                    new DirectoryWatcherIndentifier(new WatchForFinanceDataFactory(new SaveFinanceData(), new ReadFinanceDataFactory(),
                        new BackupFinanceDataFactory())), true)
            };

            HasConfiguration = Configurations.Any();
        }

        public IEnumerable<FlatFilePullIntegration> Configurations { get; private set; }
        public bool HasConfiguration { get; private set; }
    }
}