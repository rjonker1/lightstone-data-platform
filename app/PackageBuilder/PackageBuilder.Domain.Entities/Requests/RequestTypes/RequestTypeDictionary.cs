using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using PackageBuilder.Domain.Entities.Requests.RequestTypes.Configurations;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Entities.Requests.RequestTypes
{
    public static class RequestTypeDictionary
    {
        public static readonly IDictionary<DataProviderName, Func<RequestBuilderContext, IAmDataProviderRequest>>
            RequestTypes = new Dictionary<DataProviderName, Func<RequestBuilderContext, IAmDataProviderRequest>>()
            {
                {
                    DataProviderName.IVIDVerify_E_WS,
                    (context) => new IvidRequest(context.Requests, context.PackageName, context.User, context.ContactNumber)
                },
                {
                    DataProviderName.LSAutoCarStats_I_DB, (context) => new LightstoneAutoRequest(context.Requests)
                },
                {
                    DataProviderName.IVIDTitle_E_WS, (context) => new IvidTitleHolderRequest(context.Requests, context.User, context.ContactNumber)
                },
                {
                    DataProviderName.LSAutoSpecs_I_DB, (context) => new RgtRequest(context.Requests)
                }
                ,
                {
                    DataProviderName.LSAutoVINMaster_I_DB, (context) => new RgtVinRequest(context.Requests)
                },
                {
                    DataProviderName.LSPropertySearch_E_WS, (context) => new LightstonePropertyRequest(context.Requests)
                },
                {
                    DataProviderName.LSBusinessCompany_E_WS, (context) => new LightstoneCompanyRequest(context.Requests)
                },
                {
                    DataProviderName.LSBusinessDirector_E_WS, (context) => new LightstoneDirectorRequest(context.Requests)
                },
                {
                    DataProviderName.PCubedEZScore_E_WS, (context) => new PCubedEzScoreRequest(context.Requests)
                },
                {
                    DataProviderName.LSConsumerRepair_E_WS,
                    (context) => new LightstoneConsumerSpecificationsRequest(context.Requests)
                },
                {
                    DataProviderName.LSAutoDecryptDriverLic_I_WS, (context) => new SignioDriversLicenseRequest(context.Requests)
                },
                {
                    DataProviderName.BMWFSTitle_E_DB, (context) => new BmwFinanceRequest(context.Requests)
                },
                {
                    DataProviderName.MMCode_E_DB, (context) => new MmCodeRequest(context.Requests)
                },
                {
                    DataProviderName.LSAutoVIN12_I_DB, (context) => new Vin12Request(context.Requests)
                },
                {
                    DataProviderName.XDSVerifyID_E_WS, (context) => new XdsIdentityVerificationRequest(context.Requests)
                }
            };
    }
}