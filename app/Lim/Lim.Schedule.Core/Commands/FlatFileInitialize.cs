using Lim.Domain.Dto;
using Lim.Enums;

namespace Lim.Schedule.Core.Commands
{
    public class FlatFileInitializePullCommand
    {
        public FlatFileInitializePullCommand(Frequency frequency, PullClient client, FileInformationDto fileInformation)
        {
            Frequency = frequency;
            Client = client;
            FileInformation = fileInformation;
        }
        public readonly Frequency Frequency;
        public readonly PullClient Client;
        public readonly FileInformationDto FileInformation;
    }

    public class FlatFilePushInitializeCommand
    {
        public FlatFilePushInitializeCommand(Frequency frequency, PullClient client, FileInformationDto fileInformation)
        {
            Frequency = frequency;
            Client = client;
            FileInformation = fileInformation;
        }
        public readonly Frequency Frequency;
        public readonly PullClient Client;
        public readonly FileInformationDto FileInformation;
    }
}