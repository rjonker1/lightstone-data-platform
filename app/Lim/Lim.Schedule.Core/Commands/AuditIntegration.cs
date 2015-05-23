using System;
using Lim.Enums;

namespace Lim.Schedule.Core.Commands
{
    public class AuditIntegrationCommand
    {
        public AuditIntegrationCommand(Guid configurationKey, DateTime date, IntegrationAction action, IntegrationType type, string address, string suffix)
        {
            ConfigurationKey = configurationKey;
            Date = date;
            Action = action;
            Type = type;
            Address = address;
            Suffix = suffix;
        }

        public void Successful()
        {
            WasSuccessful = true;
        }

        public void Failed()
        {
            WasSuccessful = false;
        }

        public void SetPayload(string payload)
        {
            Payload = payload;
        }

        public Guid ConfigurationKey { get; private set; }
        public DateTime Date { get; private set; }
        public IntegrationAction Action { get; private set; }
        public IntegrationType Type { get; private set; }
        public bool WasSuccessful { get; private set; }
        public string Address { get; private set; }
        public string Suffix { get; private set; }
        public string Payload { get; private set; }
    }
}