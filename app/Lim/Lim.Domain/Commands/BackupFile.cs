using System.Runtime.Serialization;
using Lim.Domain.Dto;

namespace Lim.Domain.Commands
{
   [DataContract] public class BackupFile : Command
    {
        public BackupFile(FileInformationDto file, FileInformationDto fileBackup)
        {
            File = file;
            FileBackup = fileBackup;
        }

        [DataMember]
        public readonly FileInformationDto File;
        [DataMember]
        public readonly FileInformationDto FileBackup;
    }
}