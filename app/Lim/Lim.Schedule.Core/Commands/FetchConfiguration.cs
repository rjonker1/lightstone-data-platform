using System;
using Lim.Enums;
using Microsoft.SqlServer.Server;

namespace Lim.Schedule.Core.Commands
{
    public class FetchConfigurationCommand
    {
        public FetchConfigurationCommand(IntegrationAction action, IntegrationType type, Frequency frequency)
        {
            Type = type;
            Action = action;
            Frequency = frequency;
        }

        public readonly IntegrationType Type;
        public readonly IntegrationAction Action;
        public readonly Frequency Frequency;
    }

    public class FetchConfigurationForCustomCommand
    {
        public FetchConfigurationForCustomCommand(IntegrationAction action, IntegrationType type, Frequency frequency, string customDay)
        {
            Type = type;
            Action = action;
            Frequency = frequency;
            CustomDay = customDay;
        }

        public readonly IntegrationType Type;
        public readonly IntegrationAction Action;
        public readonly Frequency Frequency;
        public readonly string CustomDay;
    }

    public class FetchConfigurationForClientCommand
    {
        public FetchConfigurationForClientCommand(IntegrationAction action, IntegrationType type, Frequency frequency, Guid contractId, Guid packageId)
        {
            Type = type;
            Action = action;
            Frequency = frequency;
            ContractId = contractId;
            PackageId = packageId;
        }

        public readonly Guid ContractId;
        public readonly Guid PackageId;
        public readonly IntegrationType Type;
        public readonly IntegrationAction Action;
        public readonly Frequency Frequency;
    }
}