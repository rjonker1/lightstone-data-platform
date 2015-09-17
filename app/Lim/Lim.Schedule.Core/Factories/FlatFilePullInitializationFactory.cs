using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lim.Core;
using Lim.Domain.Base;
using Lim.Domain.Dto;
using Lim.Enums;
using Lim.Schedule.Core.Commands;
using Toolbox.Bmw.Finance;

namespace Lim.Schedule.Core.Factories
{
    public class FlatFilePullInitializationFactory : AbstractInitilizationFactory<FlatFilePullInitializeCommand>
    {
        private static readonly ILog Log = LogManager.GetLogger<FlatFilePullInitializationFactory>();

        public override void Init(FlatFilePullInitializeCommand command)
        {
            var frequency = _frequencies.Where(w => w.Key == command.Frequency).ToList();
            if (!frequency.Any())
            {
                Log.ErrorFormat("There are no Flat File Configurations to Initialize for Freqeuncy {0}", command.Frequency);
                return;
            }

            frequency.ForEach(f =>
            {
                var client = f.Value.Where(w => w.Key == command.Client).ToList();
                client.ForEach(cf =>
                {
                    cf.Value().Intialize(command.FileInformation);
                });
            });
        }

        private readonly IDictionary<Frequency, IDictionary<PullClient, Func<IWatchDirectory<FileInformationDto>>>> _frequencies = new Dictionary
            <Frequency, IDictionary<PullClient, Func<IWatchDirectory<FileInformationDto>>>>()
        {
            {Frequency.AlwaysOn, FlatFilePullers}
        };

        private static readonly IDictionary<PullClient, Func<IWatchDirectory<FileInformationDto>>> FlatFilePullers = new Dictionary
            <PullClient, Func<IWatchDirectory<FileInformationDto>>>()
        {
            {
                PullClient.Bmw, () => new WatchForFinanceDataFactory(new SaveFinanceData(), new ReadFinanceDataFactory(),
                    new BackupFinanceDataFactory())
            }
        };
    }
}