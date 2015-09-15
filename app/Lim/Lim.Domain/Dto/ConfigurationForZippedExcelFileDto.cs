using System.Runtime.Serialization;

namespace Lim.Domain.Dto
{
    [DataContract]
    public class ConfigurationForZippedExcelFileDto
    {
        public ConfigurationForZippedExcelFileDto(string filePath, string zippedFileName, string fileName, string password)
        {
            FilePath = filePath;
            ZippedFileName = zippedFileName;
            FileName = fileName;
            Password = password;
        }

        [DataMember] public readonly string FilePath;
        [DataMember] public readonly string ZippedFileName;
        [DataMember] public readonly string ZippedFilePath;
        [DataMember] public readonly string FileName;
        [DataMember] public readonly string Password;
        [DataMember] public readonly bool FirstRowIsColumnName;
    }
}
