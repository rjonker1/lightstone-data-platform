using System.Linq;
using System.Runtime.Serialization;

namespace DataPlatform.Shared.Enums
{
    [DataContract]
    public enum DataProviderCommandSource
    {
        [EnumMember(Value = "Audatex")] Audatex = 0,
        [EnumMember(Value = "Ivid")] IVIDVerify_E_WS = 1,
        [EnumMember(Value = "Ivid Title Holder")] IVIDTitle_E_WS = 2,
        [EnumMember(Value = "Rgt Vin")] LSAutoVINMaster_I_DB = 3,
        [EnumMember(Value = "Rgt")] LSAutoSpecs_I_DB = 4,
        [EnumMember(Value = "Lightstone Auto")] LSAutoCarStats_I_DB = 5,
        [EnumMember] EntryPoint = 6,
        [EnumMember] Initialization = 7,
        [EnumMember] Anpr = 8,
        [EnumMember] Jis = 9,
        [EnumMember(Value = "PCubed - Fica")] PCubedFica_E_WS = 10,
        [EnumMember(Value = "Drivers License")] LSAutoDecryptDriverLic_I_WS = 11,
        [EnumMember(Value = "LS Property")] LSPropertySearch_E_WS = 12,
        [EnumMember(Value = "LS Business")] LSBusinessCompany_E_WS = 13,
        [EnumMember(Value = "LS Director")] LSBusinessDirector_E_WS = 14,
        [EnumMember(Value = "Ez Score")] PCubedEZScore_E_WS = 15,
        [EnumMember(Value = "LS Consumer")] LSConsumerRepair_E_WS = 16,
        [EnumMember(Value = "BMW Finance")] BMWFSTitle_E_DB = 17,
        [EnumMember(Value = "LS MM Code")] MMCode_E_DB = 18,
        [EnumMember(Value = "LS Vin 12")] LSAutoVIN12_I_DB = 19,
        [EnumMember(Value = "XDS ID Verification")] XDSVerifyID_E_WS = 21
    }

    public static class SharedEnumExtensions
    {
        public static string Description(this DataProviderCommandSource value)
        {
            var attribute =
                value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(EnumMemberAttribute), false).SingleOrDefault() as
                    EnumMemberAttribute;
            return attribute == null ? value.ToString() : attribute.Value;
        }
    }
}

