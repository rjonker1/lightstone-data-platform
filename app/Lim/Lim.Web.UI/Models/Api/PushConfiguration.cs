using System;
using System.Collections.Generic;
using System.Linq;
using Lim.Enums;
using Lim.Web.UI.Commands;
using Lim.Web.UI.Handlers;

namespace Lim.Web.UI.Models.Api
{
    public class PushConfiguration
    {
        public readonly int ActionType;
        public readonly int IntegrationType;

        public PushConfiguration()
        {
            ActionType = (int) IntegrationAction.Push;
            IntegrationType = (int) Enums.IntegrationType.Api;
        }

        private PushConfiguration(Configuration configuration)
        {
            Id = configuration.Id;
            Key = configuration.Key;
            ActionType = (int)IntegrationAction.Push;
            IntegrationType = (int)Enums.IntegrationType.Api;
            FrequencyType = configuration.FrequencyType;
            ClientId = configuration.ClientId;
            ContractId = configuration.ContractId;
            AccountNumber = configuration.AccountNumber;
            IsActive = configuration.IsActive;
        }

        private PushConfiguration(List<PushConfigurationView> configuration)
        {
            Id = configuration.First().Id;
            Key = configuration.First().Key;
            //ConfigurationApiId = configurationApiId;
            ActionType = configuration.First().ActionType;
            IntegrationType = configuration.First().IntegrationType;
            FrequencyType = configuration.First().FrequencyType;
            ClientId = configuration.First().ClientId;
            ContractId = configuration.First().ContractId;
            AccountNumber = configuration.First().AccountNumber;
            IsActive = configuration.First().IsActive;

            Packages = configuration.Select(s => s.PackageId);
            BaseAddress = configuration.First().BaseAddress;
            Suffix = configuration.First().Suffix;
            Username = configuration.First().Username;
            Password = configuration.First().Password;
            HasAuthentication = configuration.First().HasAuthentication;
            AuthenticationToken = configuration.First().AuthenticationToken;
            AuthenticationKey = configuration.First().AuthenticationKey;
            AuthenticationType = configuration.First().AuthenticationType;
            ClientIdAccountNumber = configuration.First().AccountNumber;
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

        public void SetClients(IHandleGettingClient handler, GetClients command)
        {
            handler.Handle(command);
            SelectableClients = command.Clients.ToList();
        }

        public void SetPackages(IHandleGettingClient handler, GetClientPackages command)
        {
            handler.Handle(command);
            SelectablePackages = command.Packages.ToList();
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

        public void SetContracts(IHandleGettingClient handler, GetClientContracts command)
        {
            handler.Handle(command);
            SelectableContracts = command.Contracts.ToList();
        }

        public PushConfiguration SplitAccountAndClientId()
        {
            if(string.IsNullOrEmpty(ClientIdAccountNumber))
                return this;

            var data = ClientIdAccountNumber.Split('|');
            ClientId = new Guid(data[0]);
            AccountNumber = data[1];
            return this;
        }

        //public Configuration Configuration { get; set; }
        public long Id { get; private set; }
        public Guid Key { get; private set; }
        public int FrequencyType { get; set; }
        public Guid ClientId { get; set; }
        public Guid ContractId { get; set; }
        public string AccountNumber { get; set; }
        public bool IsActive { get; set; }
        public long ConfigurationApiId { get; private set; }
        public IEnumerable<Guid> Packages { get; set; }
        public string BaseAddress { get; set; }
        public string Suffix { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool HasAuthentication { get; set; }
        public string AuthenticationToken { get; set; }
        public string AuthenticationKey { get; set; }
        public int AuthenticationType { get; set; }
        public string ClientIdAccountNumber { get; set; }

        public IReadOnlyCollection<Client> SelectableClients;

        public IReadOnlyCollection<Package> SelectablePackages;

        public IReadOnlyCollection<Contract> SelectableContracts; 

        public IReadOnlyCollection<AuthenticationType> Authentication;

        public IReadOnlyCollection<FrequencyType> Frequency;

        
    }
}