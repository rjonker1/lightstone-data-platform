using System.Runtime.Serialization;
using Lim.Dtos;

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