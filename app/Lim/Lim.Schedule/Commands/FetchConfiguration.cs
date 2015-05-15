using Lim.Enums;

namespace Lim.Schedule.Commands
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
}