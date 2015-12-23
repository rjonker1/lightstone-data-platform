using System;
using System.Collections.Generic;
using System.Linq;
using Lim.Domain.Client.Commands;
using Lim.Domain.Client.Handlers;
using Lim.Domain.Lookup.Commands;
using Lim.Domain.Push.Commands;
using Lim.Dtos;
using Lim.Enums;

namespace Lim.Domain.Push.Api.DataPlatform
{
    public class PushApiDataPlatformConfiguration
    {
        public readonly short ActionType;
        public readonly short IntegrationType;

        public PushApiDataPlatformConfiguration()
        {
            ActionType = (int) IntegrationAction.Push;
            IntegrationType = (int) Enums.IntegrationType.Api;
        }

        private PushApiDataPlatformConfiguration(ConfigurationApiDto configuration)
        {
            Id = configuration.Configuration.Id;
            Key = configuration.Configuration.ConfigurationKey;
            ConfigurationApiId = configuration.Id;
            ActionType = configuration.Configuration.ActionType;
            IntegrationType = configuration.Configuration.IntegrationType;
            FrequencyType = configuration.Configuration.FrequencyType;
            IntegrationClients = configuration.Configuration.IntegrationClients != null ? configuration.Configuration.IntegrationClients.Select(s => s.ClientCustomerId) : Enumerable.Empty<Guid>();
            IntegrationContracts = configuration.Configuration.IntegrationContracts != null ? configuration.Configuration.IntegrationContracts.Select(s => s.Contract) : Enumerable.Empty<Guid>();
            IsActive = configuration.Configuration.IsActive;
            ClientId = configuration.Configuration.ClientId;
            IntegrationPackages = configuration.Configuration.IntegrationPackages != null ? configuration.Configuration.IntegrationPackages.Select(s => s.PackageId) : Enumerable.Empty<Guid>();
            BaseAddress = configuration.BaseAddress;
            Suffix = configuration.Suffix;
            Username = configuration.Username;
            Password = configuration.Password;
            HasAuthentication = configuration.HasAuthentication;
            AuthenticationToken = configuration.AuthenticationToken;
            AuthenticationKey = configuration.AuthenticationKey;
            AuthenticationType = configuration.AuthenticationType;
            CustomFrequency = DateTime.Now.Date + (configuration.Configuration.CustomFrequencyTime ?? TimeSpan.Parse("00:00"));
            CustomDay = configuration.Configuration.CustomFrequencyDay;
        }

        public static PushApiDataPlatformConfiguration Existing(IHandleGettingConfiguration handler, GetApiPushConfiguration command)
        {
            handler.Handle(command);
            return new PushApiDataPlatformConfiguration(command.ApiConfiguration);
        }

        public static PushApiDataPlatformConfiguration Create()
        {
            return new PushApiDataPlatformConfiguration();
        }

        public void SetDataPlatformClients(List<DataPlatformClientDto> clients)
        {
            SelectableDataPlatformClients = clients;
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