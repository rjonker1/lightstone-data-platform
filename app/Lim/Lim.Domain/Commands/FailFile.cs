using Lim.Domain.Dto;

namespace Lim.Domain.Commands
{
    public class FailFile
    {
        public FailFile(FileInformationDto file, FileInformationDto fileFail)
        {
            File = file;
            FileFail = fileFail;
        }

        public readonly FileInformationDto File;
        public readonly FileInformationDto FileFail;
    }
}
