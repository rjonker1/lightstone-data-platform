using System;
using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using PackageBuilder.Domain.Requests.Fields;

namespace PackageBuilder.Domain.Entities.Requests
{
    public interface IBuildRequestTypes
    {
        IEnumerable<KeyValuePair<DataProviderName, Func<RequestBuilderContext, IAmDataProviderRequest>>>
            RequestTypes { get; }
    }

    public class RequestBuilderContext
    {
        public RequestBuilderContext(ICollection<IAmRequestField> requests, IHaveUser user, string packageName, string contactNumber)
        {
            Requests = requests;
            User = user;
            PackageName = packageName;
            ContactNumber = contactNumber;
        }

        public readonly ICollection<IAmRequestField>  Requests;
        public readonly IHaveUser User;
        public readonly string ContactNumber;
        public readonly string PackageName;
    }

    public class RequestTypeBuilder : IBuildRequestTypes
    {
        private readonly IDictionary<DataProviderName, Func<RequestBuilderContext, IAmDataProviderRequest>>
            _requestTypes = new Dictionary<DataProviderName, Func<RequestBuilderContext, IAmDataProviderRequest>>()
            {
                {
                    DataProviderName.IVIDVerify_E_WS, (context) => new IvidRequest(context.Requests, context.PackageName, context.User,context.ContactNumber)
                },
                {
                    DataProviderName.LSAutoCarStats_I_DB, (context) => new LightstoneAutoRequest(context.Requests)
                },
                {
                    DataProviderName.IVIDTitle_E_WS, (context) => new IvidTitleHolderRequest(context.Requests, context.User,context.ContactNumber)
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
                } ,
                {
                    DataProviderName.LSAutoVIN12_I_DB, (context) => new Vin12Request(context.Requests)
                }
            };

        public IEnumerable<KeyValuePair<DataProviderName, Func<RequestBuilderContext, IAmDataProviderRequest>>> RequestTypes
        {
            get { return _requestTypes; }
        }
    }

    public class RgtVinRequest : IAmRgtVinRequest
    {
        public RgtVinRequest(ICollection<IAmRequestField> requestFields)
        {
            VinNumber = requestFields.GetRequestField<IAmVinNumberRequestField>();
        }

        public IAmVinNumberRequestField VinNumber { get; private set; }
    }

    public class RgtRequest : IAmRgtRequest
    {
        public RgtRequest(ICollection<IAmRequestField> requestFields)
        {
            CarId = requestFields.GetRequestField<IAmCarIdRequestField>();
        }

        public IAmCarIdRequestField CarId { get; private set; }
    }
    
    public class MmCodeRequest : IAmMmCodeRequest
    {
        public MmCodeRequest(ICollection<IAmRequestField> requestFields)
        {
            CarId = requestFields.GetRequestField<IAmCarIdRequestField>();
        }

        public IAmCarIdRequestField CarId { get; private set; }
    }

    public class IvidTitleHolderRequest : IAmIvidTitleholderRequest
    {
        public IvidTitleHolderRequest(ICollection<IAmRequestField> requestFields, IHaveUser user, string contactNumber)
        {
            RequesterName = new RequesterNameRequestField(user.UserFirstName);
            RequesterEmail = new RequesterEmailRequestField(user.UserName);
            RequesterPhone = new RequesterPhoneRequestField(contactNumber);
            VinNumber = requestFields.GetRequestField<IAmVinNumberRequestField>();
        }

        public IAmRequesterNameRequestField RequesterName { get; private set; }

        public IAmRequesterPhoneRequestField RequesterPhone { get; private set; }

        public IAmRequesterEmailRequestField RequesterEmail { get; private set; }

        public IAmVinNumberRequestField VinNumber { get; private set; }
    }

    public class XdsIdentificationVerificationRequest : IAmXdsIdentificationVerificationRequest
    {
        public XdsIdentificationVerificationRequest(ICollection<IAmRequestField> requestFields)
        {
            IdNumber = requestFields.GetRequestField<IAmIdentityNumberRequestField>();
            CellularNumber = requestFields.GetRequestField<IAmCellularNumberRequestField>();
            AccountNumber = requestFields.GetRequestField<IAmAccountNumberRequestField>();
        }

        public IAmIdentityNumberRequestField IdNumber { get; private set; }

        public IAmCellularNumberRequestField CellularNumber { get; private set; }

        public IAmAccountNumberRequestField AccountNumber { get; private set; }
    }

    public class LightstoneAutoRequest : IAmLightstoneAutoRequest
    {
        public LightstoneAutoRequest(ICollection<IAmRequestField> requestFields)
        {
            VinNumber = requestFields.GetRequestField<IAmVinNumberRequestField>();
            CarId = requestFields.GetRequestField<IAmCarIdRequestField>();
            Make = requestFields.GetRequestField<IAmMakeRequestField>();
            Year = requestFields.GetRequestField<IAmYearRequestField>();
        }

        public IAmCarIdRequestField CarId { get; private set; }

        public IAmYearRequestField Year { get; private set; }

        public IAmMakeRequestField Make { get; private set; }

        public IAmVinNumberRequestField VinNumber { get; private set; }
    }

    public class Vin12Request : IAmVin12Request
    {
        public Vin12Request(ICollection<IAmRequestField> requestFields)
        {
            VinNumber = requestFields.GetRequestField<IAmVinNumberRequestField>();
        }

        public IAmVinNumberRequestField VinNumber { get; private set; }
    }

    public class LightstonePropertyRequest : IAmLightstonePropertyRequest
    {
        public LightstonePropertyRequest(ICollection<IAmRequestField> requestFields)
        {
            UserId = new UserIdRequestField(System.Configuration.ConfigurationManager.AppSettings["LightstonePropertyUserId"]);
            IdentityNumber = requestFields.GetRequestField<IAmIdentityNumberRequestField>();
            TrackingNumber = new TrackingNumberRequestField(Guid.NewGuid().ToString());
            MaxRowsToReturn =
                new MaxRowsToReturnRequestField(System.Configuration.ConfigurationManager.AppSettings["LightstonePropertyMaxRowsToReturn"] ?? "1");
        }

        public IAmUserIdRequestField UserId { get; private set; }

        public IAmIdentityNumberRequestField IdentityNumber { get; private set; }

        public IAmTrackingNumberRequestField TrackingNumber { get; private set; }

        public IAmMaxRowsToReturnRequestField MaxRowsToReturn { get; private set; }
    }

    public class IvidRequest : IAmIvidStandardRequest
    {
        public IvidRequest(ICollection<IAmRequestField> requestFields, string pacakgeName, IHaveUser user, string contactNumber)
        {
            ApplicantName = new ApplicantNameRequestField(user.UserName);
            LicenceNumber = requestFields.GetRequestField<IAmLicenceNumberRequestField>();
            RegisterNumber = requestFields.GetRequestField<IAmRegisterNumberRequestField>();
            EngineNumber = requestFields.GetRequestField<IAmEngineNumberRequestField>();
            VinNumber = requestFields.GetRequestField<IAmVinNumberRequestField>();
            RequesterPhone = new RequesterPhoneRequestField(contactNumber);
            Label = new LabelRequestField(pacakgeName);
            RequesterEmail = new RequesterEmailRequestField(user.UserName);
            RequesterName = new RequesterNameRequestField(user.UserFirstName);
        }


        public IAmRequesterNameRequestField RequesterName { get; private set; }

        public IAmRequesterPhoneRequestField RequesterPhone { get; private set; }

        public IAmRequesterEmailRequestField RequesterEmail { get; private set; }

        public IAmRequestReferenceRequestField RequestReference { get; private set; }

        public IAmApplicantNameRequestField ApplicantName { get; private set; }
        public IAmReasonForApplicationRequestField ReasonForApplication { get; private set; }

        public IAmLabelRequestField Label { get; private set; }

        public IAmEngineNumberRequestField EngineNumber { get; private set; }

        public IAmChassisNumberRequestField ChassisNumber { get; private set; }

        public IAmVinNumberRequestField VinNumber { get; private set; }

        public IAmLicenceNumberRequestField LicenceNumber { get; private set; }

        public IAmRegisterNumberRequestField RegisterNumber { get; private set; }

        public IAmMakeRequestField Make { get; private set; }
    }

    public class LightstoneDirectorRequest : IAmLightstoneBusinessDirectorRequest
    {
        public LightstoneDirectorRequest(ICollection<IAmRequestField> requestFields)
        {
            IdNumber = requestFields.GetRequestField<IAmIdentityNumberRequestField>();
            FirstName = requestFields.GetRequestField<IAmFirstNameRequestField>();
            Surname = requestFields.GetRequestField<IAmSurnameRequestField>();
        }

        public IAmIdentityNumberRequestField IdNumber { get; private set; }
        public IAmFirstNameRequestField FirstName { get; private set; }
        public IAmSurnameRequestField Surname { get; private set; }
    }

    public class LightstoneConsumerSpecificationsRequest : IAmLightstoneConsumerSpecificationsRequest
    {
        public LightstoneConsumerSpecificationsRequest(ICollection<IAmRequestField> requestFields)
        {
            VinNumber = requestFields.GetRequestField<IAmVinNumberRequestField>();
            AccessKey = requestFields.GetRequestField<IAmAccessKeyRequestField>();
        }

        public IAmVinNumberRequestField VinNumber { get; private set; }
        public IAmAccessKeyRequestField AccessKey { get; private set; }
    }

    public class PCubedEzScoreRequest : IAmPCubedEzScoreRequest
    {
        public PCubedEzScoreRequest(ICollection<IAmRequestField> requestFields)
        {
            IdNumber = requestFields.GetRequestField<IAmIdentityNumberRequestField>();
            PhoneNumber = requestFields.GetRequestField<IAmPhoneNumberRequestField>();
            EmailAddress = requestFields.GetRequestField<IAmEmailAddressRequestField>();
        }

        public IAmIdentityNumberRequestField IdNumber { get; private set; }
        public IAmPhoneNumberRequestField PhoneNumber { get; private set; }
        public IAmEmailAddressRequestField EmailAddress { get; private set; }
    }

    public class LightstoneCompanyRequest : IAmLightstoneBusinessCompanyRequest
    {
        public LightstoneCompanyRequest(ICollection<IAmRequestField> requestFields)
        {
            CompanyName = requestFields.GetRequestField<IAmCompanyNameRequestField>();
            CompanyRegistrationNumber = requestFields.GetRequestField<IAmCompanyRegistrationNumberRequestField>();
            CompanyVatNumber = requestFields.GetRequestField<IAmCompanyVatNumberRequestField>();
        }

        public IAmCompanyNameRequestField CompanyName { get; private set; }

        public IAmCompanyRegistrationNumberRequestField CompanyRegistrationNumber { get; private set; }

        public IAmCompanyVatNumberRequestField CompanyVatNumber { get; private set; }
    }

    public class SignioDriversLicenseRequest : IAmSignioDriversLicenseDecryptionRequest
    {
        public SignioDriversLicenseRequest(ICollection<IAmRequestField> requestFields)
        {
            ScanData = requestFields.GetRequestField<IAmScanDataRequestField>();
            RegistrationCode = requestFields.GetRequestField<IAmRegistrationCodeRequestField>();
            Username = requestFields.GetRequestField<IAmUserNameRequestField>();
            UserId = requestFields.GetRequestField<IAmUserIdRequestField>();
        }

        public IAmScanDataRequestField ScanData { get; private set; }

        public IAmRegistrationCodeRequestField RegistrationCode { get; private set; }

        public IAmUserNameRequestField Username { get; private set; }

        public IAmUserIdRequestField UserId { get; private set; }
    }

    public class BmwFinanceRequest : IAmBmwFinanceRequest
    {
        public BmwFinanceRequest(ICollection<IAmRequestField> requestFields)
        {
            AccountNumber = requestFields.GetRequestField<IAmAccountNumberRequestField>();
            VinNumber = requestFields.GetRequestField<IAmVinNumberRequestField>();
            IdNumber = requestFields.GetRequestField<IAmIdentityNumberRequestField>();
            LicenceNumber = requestFields.GetRequestField<IAmLicenceNumberRequestField>();
            EngineNumber = requestFields.GetRequestField<IAmEngineNumberRequestField>();
        }

        public IAmAccountNumberRequestField AccountNumber { get; private set; }

        public IAmVinNumberRequestField VinNumber { get; private set; }

        public IAmIdentityNumberRequestField IdNumber { get; private set; }

        public IAmLicenceNumberRequestField LicenceNumber { get; private set; }
        public IAmEngineNumberRequestField EngineNumber { get; private set; }

    }

    public static class RequestFieldExtensions
    {
        public static T GetRequestField<T>(this ICollection<IAmRequestField> requestFields)
        {
            return requestFields.OfType<T>().Any() ? requestFields.OfType<T>().First() : default(T);
        }
    }
}