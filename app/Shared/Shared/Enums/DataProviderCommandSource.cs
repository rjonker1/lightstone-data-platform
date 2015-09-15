﻿using System.Runtime.Serialization;

namespace DataPlatform.Shared.Enums
{
    [DataContract]
    public enum DataProviderCommandSource
    {
        [EnumMember] Audatex,
        [EnumMember] IVIDVerify_E_WS,
        [EnumMember] IVIDTitle_E_WS,
        [EnumMember] LSAutoVINMaster_I_DB,
        [EnumMember] LSAutoSpecs_I_DB,
        [EnumMember] LSAutoCarStats_I_DB,
        [EnumMember] EntryPoint,
        [EnumMember] Initialization,
        [EnumMember] Anpr,
        [EnumMember] Jis,
        [EnumMember] PCubedFica_E_WS,
        [EnumMember] LSAutoDecryptDriverLic_I_WS,
        [EnumMember] LSPropertySearch_E_WS,
        [EnumMember] LSBusinessCompany_E_WS,
        [EnumMember] LSBusinessDirector_E_WS,
        [EnumMember] PCubedEZScore_E_WS,
        [EnumMember] LSConsumerRepair_E_WS,
        [EnumMember] BMWFSTitle_E_DB
    }

    // Legacy - 15/09/2015
    //[DataContract]
    //public enum DataProviderCommandSource
    //{
    //    [EnumMember] Audatex,
    //    [EnumMember] Ivid,
    //    [EnumMember] IvidTitleHolder,
    //    [EnumMember] RgtVin,
    //    [EnumMember] Rgt,
    //    [EnumMember] LightstoneAuto,
    //    [EnumMember] EntryPoint,
    //    [EnumMember] Initialization,
    //    [EnumMember] Anpr,
    //    [EnumMember] Jis,
    //    [EnumMember] PCubedFica,
    //    [EnumMember] SignioDecryptDriversLicense,
    //    [EnumMember] LightstoneProperty,
    //    [EnumMember] LightstoneBusinessCompany,
    //    [EnumMember] LightstoneBusinessDirector,
    //    [EnumMember] PCubedEzScore,
    //    [EnumMember] LightstoneConsumerSpecifications,
    //    [EnumMember] BmwFinance
    //}
}