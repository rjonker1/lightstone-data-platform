using System;
using System.Collections.Generic;
using System.Linq;
using Lim.Domain.Dto;
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

        public static PullConfiguration Create()
        {
            return new PullConfiguration();
        }

        public long Id { get; private set; }
        public Guid Key { get; private set; }
        public int FrequencyType { get; set; }
        public long ClientId { get; set; }
        public IEnumerable<Guid> IntegrationClients { get; set; }
        public IEnumerable<Guid> IntegrationContracts { get; set; }
        public int AccountNumber { get; set; }
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
        public string ClientIdAccountNumber { get; set; }
        public DateTime CustomFrequency { get; set; }
        public string CustomDay { get; set; }

        public IReadOnlyCollection<ClientDto> SelectableIntegrationClients;

        public IReadOnlyCollection<DataPlatformClientDto> SelectableDataPlatformClients;

        public IReadOnlyCollection<AuthenticationTypeDto> Authentication;

        public IReadOnlyCollection<FrequencyTypeDto> Frequency;

        public IReadOnlyCollection<DataPlatformContractDto> SelectableDataPlatformContracts;

        public IReadOnlyCollection<WeekdayDto> Weekdays;
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

        public void SetWeekdays(IHandleGettingConfiguration handler, GetWeekdays command)
        {
            handler.Handle(command);
            Weekdays = command.Weekdays.ToList();
        }

        public void SetIntegrationClients(IHandleGettingIntegrationClient handler, GetIntegrationClients command)
        {
            handler.Handle(command);
            SelectableIntegrationClients = command.Clients.ToList();
        }
    }
}