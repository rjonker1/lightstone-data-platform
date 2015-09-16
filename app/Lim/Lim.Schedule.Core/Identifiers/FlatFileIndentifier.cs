using System.Runtime.Serialization;

namespace Lim.Schedule.Core.Identifiers
{
    [DataContract]
    public class FlatFileIndentifier
    {
        public FlatFileIndentifier(string filePath, string fileName, bool firstRowIsColumnName, string password, bool hasPassword, string extension)
        {
            FilePath = filePath;
            FileName = fileName;
            FirstRowIsColumnName = firstRowIsColumnName;
            Password = password;
            HasPassword = hasPassword;
            Extension = extension;
        }

        [DataMember] public readonly string FilePath;
        [DataMember] public readonly string FileName;
        [DataMember]
        public readonly string Password;
        [DataMember]
        public readonly bool HasPassword;
        [DataMember] public readonly bool FirstRowIsColumnName;
        [DataMember] public readonly string Extension;
    }
}