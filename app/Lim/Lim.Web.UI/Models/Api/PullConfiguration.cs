﻿using System;
using System.Collections.Generic;
using System.Linq;
using Lim.Enums;
using Lim.Web.UI.Commands;
using Lim.Web.UI.Handlers;

namespace Lim.Web.UI.Models.Api
{
    public class PullConfiguration
    {
        public readonly int ActionType;
        public readonly int IntegrationType;

        public PullConfiguration()
        {
            ActionType = (int) IntegrationAction.Push;
            IntegrationType = (int) Enums.IntegrationType.Api;
        }

        private PullConfiguration(Configuration configuration)
        {
            Id = configuration.Id;
            Key = configuration.Key;
            ActionType = (int) IntegrationAction.Pull;
            IntegrationType = (int) Enums.IntegrationType.Api;
            FrequencyType = configuration.FrequencyType;
            ClientId = configuration.ClientId;
            ContractId = configuration.ContractId;
            AccountNumber = configuration.AccountNumber;
            IsActive = configuration.IsActive;
        }

        public static PullConfiguration Create()
        {
            return new PullConfiguration();
        }

        // public Configuration Configuration { get; private set; }
        public long Id { get; private set; }
        public Guid Key { get; private set; }
        public int FrequencyType { get; set; }
        public Guid ClientId { get; set; }
        public Guid ContractId { get; set; }
        public string AccountNumber { get; set; }
        public bool IsActive { get; set; }
        public long ConfigurationApiId { get; private set; }
        public string BaseAddress { get; set; }
        public string Suffix { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool HasAuthentication { get; set; }
        public string AuthenticationToken { get; set; }
        public string AuthenticationKey { get; set; }
        public int AuthenticationType { get; set; }

        public IReadOnlyCollection<Client> SelectableClients;

        public IReadOnlyCollection<AuthenticationType> Authentication;

        public IReadOnlyCollection<FrequencyType> Frequency;

        public IReadOnlyCollection<Contract> SelectableContracts;

        public void SetClients(IHandleGettingClient handler)
        {
            var command = new GetClients();
            handler.Handle(command);
            SelectableClients = command.Clients.ToList();
        }

        public void SetAuthentication(IHandleGettingConfiguration handler)
        {
            var command = new GetAuthenticationTypes();
            handler.Handle(command);
            Authentication = command.Authentication.ToList();
        }

        public void SetFrequency(IHandleGettingConfiguration handler)
        {
            var command = new GetFrequencyTypes();
            handler.Handle(command);
            Frequency = command.Frequency.ToList();
        }

        public void SetContracts(IHandleGettingClient handler, GetClientContracts command)
        {
            handler.Handle(command);
            SelectableContracts = command.Contracts.ToList();
        }
    }
}