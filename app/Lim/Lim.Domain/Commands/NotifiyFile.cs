using System.Runtime.Serialization;
using Lim.Enums;

namespace Lim.Domain.Commands
{
    [DataContract]
    public class NotifyFile
    {
        public NotifyFile(string fileName, string filePath, string notification, Status status)
        {
            FileName = fileName;
            FilePath = filePath;
            Notification = notification;
            Status = status;
        }

        [DataMember] public readonly string FileName;
        [DataMember] public readonly string FilePath;
        [DataMember] public readonly string Notification;
        [DataMember] public readonly Status Status;
    }
}
