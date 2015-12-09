using System;
using System.Collections.Generic;
using System.Linq;
using Lim.Dtos;
using Lim.Enums;
using Lim.Web.UI.Commands;
using Lim.Web.UI.Handlers;

namespace Lim.Web.UI.Models.Api
{
    public class PushConfiguration
    {
        public readonly short ActionType;
        public readonly short IntegrationType;

        public PushConfiguration()
        {
            ActionType = (int) IntegrationAction.Push;
            IntegrationType = (int) Enums.IntegrationType.Api;
        }

        private PushConfiguration(PushConfigurationView configuration)
        {
            Id = configuration.Id;
            Key = configuration.Key;
            ConfigurationApiId = configuration.ApiConfigurationId;
            ActionType = configuration.ActionType;
            IntegrationType = configuration.IntegrationType;
            FrequencyType = configuration.FrequencyType;
            IntegrationClients = configuration.IntegrationClients;
            IntegrationContracts = configuration.IntegrationContracts;
            IsActive = configuration.IsActive;
            ClientId = configuration.ClientId;
            IntegrationPackages = configuration.IntegrationPackages;
            BaseAddress = configuration.BaseAddress;
            Suffix = configuration.Suffix;
            Username = configuration.Username;
            Password = configuration.Password;
            HasAuthentication = configuration.HasAuthentication;
            AuthenticationToken = configuration.AuthenticationToken;
            AuthenticationKey = configuration.AuthenticationKey;
            AuthenticationType = configuration.AuthenticationType;
            CustomFrequency = DateTime.Now.Date + (configuration.CustomFrequencyTime.HasValue ? configuration.CustomFrequencyTime.Value : TimeSpan.Parse("00:00"));
            CustomDay = configuration.CustomFrequencyDay;
        }

        public static PushConfiguration Existing(IHandleGettingConfiguration handler, GetApiPushConfiguration command)
        {
            handler.Handle(command);
            return new PushConfiguration(command.Configuration);
        }

        public static PushConfiguration Create()
        {
            return new PushConfiguration();
        }

        public void SetDataPlatformClients(IHandleGettingDataPlatformClient handler, GetDataPlatformClients command)
        {
            handler.Handle(command);
            SelectableDataPlatformClients = command.Clients.ToList();
        }

        public void SetAuthentication(IHandleGettingConfiguration handler, GetAuthenticationTypes command)
        {
            handler.Handle(command);
            Authentication = command.Authentication.ToList();
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
        public IEnumerable<Guid> IntegrationClients { get; set; }
        public IEnumerable<Guid> IntegrationContracts { get; set; }
        public bool IsActive { get; set; }
        public long ConfigurationApiId { get; private set; }
        public IEnumerable<Guid> IntegrationPackages { get; set; }
        public string BaseAddress { get; set; }
        public string Suffix { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool HasAuthentication { get; set; }
        public string AuthenticationToken { get; set; }
        public string AuthenticationKey { get; set; }
        public short AuthenticationType { get; set; }
        public DateTime CustomFrequency { get; set; }
        public string CustomDay { get; set; }
        public string User { get; set; }

        public IReadOnlyCollection<ClientDto> SelectableIntegrationClients; 

        public IReadOnlyCollection<DataPlatformClientDto> SelectableDataPlatformClients;

        public IReadOnlyCollection<AuthenticationTypeDto> Authentication;

        public IReadOnlyCollection<FrequencyTypeDto> Frequency;

        public IReadOnlyCollection<WeekdayDto> Weekdays;
    }
}