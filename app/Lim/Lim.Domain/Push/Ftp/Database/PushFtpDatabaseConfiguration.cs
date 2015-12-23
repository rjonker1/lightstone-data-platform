using System;
using System.Collections.Generic;
using System.Linq;
using Lim.Domain.Client.Commands;
using Lim.Domain.Client.Handlers;
using Lim.Domain.Lookup.Commands;
using Lim.Domain.Push.Ftp.Commands;
using Lim.Dtos;
using Lim.Enums;

namespace Lim.Domain.Push.Ftp.Database
{
    public class PushFtpDatabaseConfiguration
    {
        public readonly short ActionType;
        public readonly short IntegrationType;

        public PushFtpDatabaseConfiguration()
        {
            ActionType = (int) IntegrationAction.Push;
            IntegrationType = (int) Enums.IntegrationType.Ftp;
        }

        private PushFtpDatabaseConfiguration(ConfigurationFtpDto configuration)
        {
            Id = configuration.Configuration.Id;
            Key = configuration.Configuration.ConfigurationKey;
            ClientId = configuration.Configuration.ClientId;
            FrequencyType = configuration.Configuration.FrequencyType;
            IsActive = configuration.Configuration.IsActive;
            ConfigurationFtpId = configuration.Id;
            CustomFrequency = DateTime.Now.Date + (configuration.Configuration.CustomFrequencyTime ?? TimeSpan.Parse("00:00"));
            CustomDay = configuration.Configuration.CustomFrequencyDay;
            DatabaseExtracts = configuration.Configuration.IntegrationDataExtracts != null
                ? configuration.Configuration.IntegrationDataExtracts.Select(s => s.DataExtractId)
                : Enumerable.Empty<long>();
        }

       

        public static PushFtpDatabaseConfiguration Existing(IHandleGettingConfiguration handler, GetFtpPushConfiguration command)
        {
            handler.Handle(command);
            return new PushFtpDatabaseConfiguration(command.FtpConfiguration);
        }

        public static PushFtpDatabaseConfiguration Create()
        {
            return new PushFtpDatabaseConfiguration();
        }

        public void SetDatabaseExtracts(List<DatabaseExtractDto> databaseExtracts)
        {
            SelectableDatabaseExtracts = databaseExtracts;
        }

        public void SetFrequency(IHandleGettingConfiguration handler, GetFrequencyTypes command)
        {
            handler.Handle(command);
            Frequency = command.Frequency.ToList();
        }

        public void SetIntegrationClients(IHandleGettingIntegrationClient handler, GetIntegrationClients command)
        {
            handler.Handle(command);
            SelectableIntegrationClients = command.Clients.ToList();
        }

        public void SetWeekdays(IHandleGettingConfiguration handler, GetWeekdays command)
        {
            handler.Handle(command);
            Weekdays = command.Weekdays.ToList();
        }


        public long Id { get; private set; }
        public Guid Key { get; private set; }
        public long ClientId { get; private set; }
        public short FrequencyType { get; set; }
        public bool IsActive { get; set; }
        public long ConfigurationFtpId { get; private set; }
        public DateTime CustomFrequency { get; private set; }
        public string CustomDay { get; private set; }
        public IEnumerable<long> DatabaseExtracts { get; private set; }

        public IReadOnlyCollection<ClientDto> SelectableIntegrationClients;
        public IReadOnlyCollection<DatabaseExtractDto> SelectableDatabaseExtracts;
        public IReadOnlyCollection<FrequencyTypeDto> Frequency;
        public IReadOnlyCollection<WeekdayDto> Weekdays;
    }
}
