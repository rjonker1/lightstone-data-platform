using Lim.Domain.Dto;

namespace Lim.Domain.Commands
{
    public class BackupFile
    {
        public BackupFile(FileInformationDto file, FileInformationDto fileBackup)
        {
            File = file;
            FileBackup = fileBackup;
        }

        public readonly FileInformationDto File;
        public readonly FileInformationDto FileBackup;
    }
}