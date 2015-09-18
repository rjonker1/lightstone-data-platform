using System;
using System.Collections.Generic;
using Lim.Core;
using Lim.Domain.Base;
using Lim.Enums;
using Lim.Infrastructure;
using Lim.Schedule.Core.Commands;
using Lim.Schedule.Core.Identifiers;

namespace Lim.Schedule.Core.Factories.FlatFile
{
    public class FetchFactory : AbstractFetchFactory<FetchConfigurationCommand, List<FlatFilePullIntegration>>
    {
        private readonly IPull<FlatFileInitializePullCommand> _puller;

        public FetchFactory(IPull<FlatFileInitializePullCommand> puller)
        {
            _puller = puller;
        }

        public override List<FlatFilePullIntegration> Fetch(FetchConfigurationCommand command)
        {
            //TODO: This needs to read from the database. Its like this for now to get to work for LIVE 1.0
            return new List<FlatFilePullIntegration>()
            {
                new FlatFilePullIntegration(Guid.NewGuid(),
                    new FlatFileIndentifier(ConfigurationReader.Bmw.FilePath, ConfigurationReader.Bmw.FileName,
                        ConfigurationReader.Bmw.FirstRowIsColumnName, ConfigurationReader.Bmw.FilePassword, true,
                        ConfigurationReader.Bmw.FileExtension), new PullClientIdentifier(PullClient.Bmw.ToString(), (int) PullClient.Bmw),
                    new FrequencyIdentifier(Frequency.AlwaysOn.ToString(), (int) Frequency.AlwaysOn), _puller)
            };
        }
    }
}