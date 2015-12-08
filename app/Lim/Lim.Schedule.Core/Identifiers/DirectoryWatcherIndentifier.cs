using System.Runtime.Serialization;
using Lim.Core;
using Lim.Dtos;

namespace Lim.Schedule.Core.Identifiers
{
    [DataContract]
    public class DirectoryWatcherIndentifier
    {
        public DirectoryWatcherIndentifier(IWatch<FileInformationDto> watcher)
        {
            Watcher = watcher;
        }

        [DataMember] public readonly IWatch<FileInformationDto> Watcher;
    }
}