﻿using System.Runtime.Serialization;

namespace DataPlatform.Shared.Enums
{
    [DataContract]
    public enum DataProviderCommandSource
    {
        [EnumMember] Audatex,
        [EnumMember] Ivid,
        [EnumMember] IvidTitleHolder,
        [EnumMember] VinMaster,
        [EnumMember] LsaSpecifications,
        [EnumMember] LightstoneAuto,
        [EnumMember] EntryPoint,
        [EnumMember] Initialization,
        [EnumMember] Anpr,
        [EnumMember] Jis,
        [EnumMember] PCubedFica,
        [EnumMember] SignioDecryptDriversLicense,
        [EnumMember] LightstoneProperty,
        [EnumMember] LightstoneBusinessCompany,
        [EnumMember] LightstoneBusinessDirector,
        [EnumMember] PCubedEzScore,
        [EnumMember] LightstoneConsumerRepair,
        [EnumMember] BmwFsTitle
    }
}