using Lim.Domain.Dto;

namespace Lim.Domain.Commands
{
    public class GetContentsFromZippedExcelFile
    {
        public GetContentsFromZippedExcelFile(ConfigurationForZippedExcelFileDto zippedExcelFile)
        {
            ZippedExcelFile = zippedExcelFile;
        }

        public readonly ConfigurationForZippedExcelFileDto ZippedExcelFile;
    }
}