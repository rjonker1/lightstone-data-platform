using System.Runtime.Serialization;
namespace DataPlatform.Shared.Enums
{
    [DataContract]
    public enum MonitoringSource
    {
        [EnumMember]
        Lace = 1,
        [EnumMember]
        UserManagement = 2,
        [EnumMember]
        PackageBuilder = 3
    }
}
