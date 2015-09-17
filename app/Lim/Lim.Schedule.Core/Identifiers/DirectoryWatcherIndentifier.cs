using System.Runtime.Serialization;
using Lim.Core;
using Lim.Domain.Dto;

namespace Lim.Schedule.Core.Identifiers
{
    [DataContract]
    public class DirectoryWatcherIndentifier
    {
        public DirectoryWatcherIndentifier(IWatchDirectory<FileInformationDto> watcher)
        {
            Watcher = watcher;
        }

        [DataMember] public readonly IWatchDirectory<FileInformationDto> Watcher;
    }
}