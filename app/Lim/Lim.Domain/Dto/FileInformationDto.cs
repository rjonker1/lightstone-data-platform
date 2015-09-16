using System.Runtime.Serialization;

namespace Lim.Domain.Dto
{
    [DataContract]
    public class FileInformationDto
    {
        public FileInformationDto(string filePath, string fileName, string password, string fileExtension, bool firstRowIsColumn)
        {
            FilePath = filePath;
            FileName = fileName;
            Password = password;
            FileExtension = fileExtension;
            FirstRowIsColumnName = firstRowIsColumn;
        }

        [DataMember] public readonly string FilePath;
        [DataMember] public readonly string FileName;
        [DataMember] public readonly string Password;
        [DataMember] public readonly bool FirstRowIsColumnName;
        [DataMember] public readonly string FileExtension;
    }
}