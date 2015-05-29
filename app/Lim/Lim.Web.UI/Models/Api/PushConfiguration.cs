using System;
using System.Collections.Generic;
using System.Linq;
using Lim.Domain.Dto;
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

        private PushConfiguration(List<PushConfigurationView> configuration)
        {
            Id = configuration.First().Id;
            Key = configuration.First().Key;
            //ConfigurationApiId = configurationApiId;
            ActionType = configuration.First().ActionType;
            IntegrationType = configuration.First().IntegrationType;
            FrequencyType = configuration.First().FrequencyType;
            IntegrationClients = configuration.Select(s => s.IntegrationClientId);
            IntegrationContracts = configuration.Select(s => s.IntegrationContractId);
            AccountNumber = configuration.First().AccountNumber;
            IsActive = configuration.First().IsActive;
            ClientId = configuration.First().ClientId;
            AccountNumber = configuration.First().AccountNumber;
            IntegrationPackages = configuration.Select(s => s.IntegrationPackageId);
            BaseAddress = configuration.First().BaseAddress;
            Suffix = configuration.First().Suffix;
            Username = configuration.First().Username;
            Password = configuration.First().Password;
            HasAuthentication = configuration.First().HasAuthentication;
            AuthenticationToken = configuration.First().AuthenticationToken;
            AuthenticationKey = configuration.First().AuthenticationKey;
            AuthenticationType = configuration.First().AuthenticationType;
            ClientIdAccountNumber = string.Format("{0}|{1}", IntegrationClients, AccountNumber);
            CustomFrequency = DateTime.Now.Date + configuration.First().CustomFrequencyTime;
            CustomDay = configuration.First().CustomFrequencyDay;
        }

        public static PushConfiguration Existing(IHandleGettingConfiguration handler, GetApiPushConfiguration command)
        {
            handler.Handle(command);
            return new PushConfiguration(command.Configuration.ToList());
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
        public int AccountNumber { get; set; }
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
        public string ClientIdAccountNumber { get; set; }
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