using System.Runtime.Serialization;
using Lim.Dtos;

namespace Lim.Domain.Commands
{
   [DataContract] public class FailFile : Command
    {
        public FailFile(FileInformationDto file, FileInformationDto fileFail)
        {
            File = file;
            FileFail = fileFail;
        }

        [DataMember]
        public readonly FileInformationDto File;
        [DataMember]
        public readonly FileInformationDto FileFail;
    }
}
