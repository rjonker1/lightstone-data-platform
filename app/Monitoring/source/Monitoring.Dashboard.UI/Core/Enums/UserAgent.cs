using System.Runtime.Serialization;

namespace Monitoring.Dashboard.UI.Core.Enums
{
    public enum UserAgent
    {
        [EnumMember(Value = "iPad, Tablet")] Tablet = 1,
        [EnumMember(Value = "iPhone,Mobile")]Phone = 2,
        [EnumMember(Value = "Chrome,Firefox,Safari")] Browser = 3,
        [EnumMember(Value = "RestSharp")] Api = 4,
        [EnumMember(Value = "Undefined")] Undefined = 5
    }
}