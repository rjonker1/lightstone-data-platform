using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lim.Core;
using Lim.Domain.Base;
using Lim.Domain.Dto;
using Lim.Enums;
using Lim.Schedule.Core.Commands;
using Toolbox.Bmw.Factories;
using Toolbox.Bmw.Notify;
using Toolbox.Emailing.Smtp;

namespace Lim.Schedule.Core.Factories.FlatFile
{
    public class InitializePullFactory : AbstractInitilizationFactory<FlatFileInitializePullCommand>
    {
        private static readonly ILog Log = LogManager.GetLogger<InitializePullFactory>();

        public override void Init(FlatFileInitializePullCommand command)
        {
            var frequency = _frequencies.Where(w => w.Key == command.Frequency).ToList();
            if (!frequency.Any())
            {
                Log.ErrorFormat("There are no Flat File Configurations to Initialize for Frequency {0}", command.Frequency);
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

        private readonly IDictionary<Frequency, IDictionary<PullClient, Func<IWatch<FileInformationDto>>>> _frequencies = new Dictionary
            <Frequency, IDictionary<PullClient, Func<IWatch<FileInformationDto>>>>()
        {
            {Frequency.AlwaysOn, FlatFilePullers}
        };

        private static readonly IDictionary<PullClient, Func<IWatch<FileInformationDto>>> FlatFilePullers = new Dictionary
            <PullClient, Func<IWatch<FileInformationDto>>>()
        {
            {
                PullClient.Bmw, () => new WatchForFinanceDataFileFactory(new SaveFinanceData(), new ReadFinanceDataFileFactory(),
                    new BackupFinanceDataFileFactory(), new FailFinanceDataFileFactory(), new FileNotificationFactory(new SmtpMailDispatcher(), new HtmlMailMessageBuilder()))
            }
        };
    }
}