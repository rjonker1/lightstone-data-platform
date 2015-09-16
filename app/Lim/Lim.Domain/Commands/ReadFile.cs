using Lim.Domain.Dto;

namespace Lim.Domain.Commands
{
    public class ReadFile
    {
        public ReadFile(FileInformationDto file)
        {
            File = file;
        }

        public readonly FileInformationDto File;
    }
}