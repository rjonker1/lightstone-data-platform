using System.Runtime.Serialization;

namespace Lim.Dtos
{
    [DataContract]
    public class FileInformationDto
    {
        public FileInformationDto(string filePath, string fileName, string password, string fileExtension, bool firstRowIsColumn, bool hasPassword)
        {
            FilePath = filePath;
            FileName = fileName;
            Password = password;
            FileExtension = fileExtension;
            FirstRowIsColumnName = firstRowIsColumn;
            HasPassword = hasPassword;
        }

        [DataMember] public readonly string FilePath;
        [DataMember] public readonly string FileName;
        [DataMember] public readonly string Password;
        [DataMember] public readonly bool FirstRowIsColumnName;
        [DataMember] public readonly string FileExtension;
        [DataMember] public readonly bool HasPassword;
    }
}