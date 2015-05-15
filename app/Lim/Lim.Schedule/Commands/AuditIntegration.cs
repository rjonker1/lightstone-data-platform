using System;
using Lim.Enums;

namespace Lim.Schedule.Commands
{
    public class AuditIntegrationCommand
    {
        public AuditIntegrationCommand(Guid configurationKey, DateTime date, IntegrationAction action, IntegrationType type)
        {
            ConfigurationKey = configurationKey;
            Date = date;
            Action = action;
            Type = type;
        }

        public void Successful()
        {
            WasSuccessful = true;
        }

        public void Failed()
        {
            WasSuccessful = false;
        }

        public Guid ConfigurationKey { get; private set; }
        public DateTime Date { get; private set; }
        public IntegrationAction Action { get; private set; }
        public IntegrationType Type { get; private set; }
        public bool WasSuccessful { get; private set; }
    }
}
