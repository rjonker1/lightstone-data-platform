using System.Runtime.Serialization;
namespace DataPlatform.Shared.Enums
{
    [DataContract]
    public enum MonitoringSource
    {
        [EnumMember]
        Lace,
        [EnumMember]
        UserManagement,
        [EnumMember]
        PackageBuilder
    }
}
