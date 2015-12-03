using System.Runtime.Serialization;
using Lim.Domain.Dto;

namespace Lim.Domain.Commands
{
    [DataContract]
    public class ReadFile : Command
    {
        public ReadFile(FileInformationDto file)
        {
            File = file;
        }

        [DataMember] public readonly FileInformationDto File;
    }
}