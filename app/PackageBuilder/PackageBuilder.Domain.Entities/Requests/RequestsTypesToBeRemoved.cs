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
        IEnumerable<KeyValuePair<DataProviderName, Func<ICollection<IAmRequestField>, IHaveUser, string, IAmDataProviderRequest>>>
            RequestTypes { get; }
    }

    public class RequestTypeBuilder : IBuildRequestTypes
    {
        private readonly IDictionary<DataProviderName, Func<ICollection<IAmRequestField>, IHaveUser, string, IAmDataProviderRequest>>
            _requestTypes = new Dictionary<DataProviderName, Func<ICollection<IAmRequestField>, IHaveUser, string, IAmDataProviderRequest>>()
            {
                {
                    DataProviderName.Ivid, Ivid
                },
                {
                    DataProviderName.LightstoneAuto, LightstoneAuto
                },
                {
                    DataProviderName.IvidTitleHolder, IvidTitleHolder
                },
                {
                    DataProviderName.Rgt, Rgt
                }
                ,
                {
                    DataProviderName.RgtVin, RgtVin
                },
                {
                    DataProviderName.LightstoneProperty, LightstoneProperty
                },
                {
                    DataProviderName.LightstoneBusinessCompany, LightstoneCompany
                },
                {
                    DataProviderName.LightstoneBusinessDirector, LightstoneDirectors
                },
                {
                    DataProviderName.PCubedEzScore, PCubedEzScore
                },
                {
                    DataProviderName.LightstoneConsumerSpecifications, LightstoneConsumerSpecifications
                }
            };

        private static readonly Func<ICollection<IAmRequestField>, IHaveUser, string, IAmDataProviderRequest> Ivid =
            (requests, user, packageName) =>
                new IvidLaceRequest(requests, packageName, user);

        private static readonly Func<ICollection<IAmRequestField>, IHaveUser, string, IAmDataProviderRequest> LightstoneAuto =
            (requests, user, packageName) =>
                new LightstoneAutoLaceRequest(requests);

        private static readonly Func<ICollection<IAmRequestField>, IHaveUser, string, IAmDataProviderRequest> IvidTitleHolder =
            (requests, user, packageName) =>
                new IvidTitleHolderLaceRequest(requests, user);

        private static readonly Func<ICollection<IAmRequestField>, IHaveUser, string, IAmDataProviderRequest> Rgt =
            (requests, user, packageName) =>
                new RgtLaceRequest(requests);

        private static readonly Func<ICollection<IAmRequestField>, IHaveUser, string, IAmDataProviderRequest> RgtVin =
            (requests, user, packageName) =>
                new RgtVinLaceReqeust(requests);

        private static readonly Func<ICollection<IAmRequestField>, IHaveUser, string, IAmDataProviderRequest> LightstoneProperty =
            (requests, user, packageName) => new LightstonePropertyLaceRequest(requests);

        private static readonly Func<ICollection<IAmRequestField>, IHaveUser, string, IAmDataProviderRequest> LightstoneCompany =
            (requests, user, packageName) => new LightstoneCompanyRequest(requests);

        private static readonly Func<ICollection<IAmRequestField>, IHaveUser, string, IAmDataProviderRequest> LightstoneDirectors =
            (requests, user, packageName) => new LightstoneDirectorRequest(requests);

        private static readonly Func<ICollection<IAmRequestField>, IHaveUser, string, IAmDataProviderRequest> LightstoneConsumerSpecifications =
            (requests, user, packageName) => new LightstoneConsumerSpecificationsRequest(requests);

        private static readonly Func<ICollection<IAmRequestField>, IHaveUser, string, IAmDataProviderRequest> PCubedEzScore =
            (requests, user, packageName) => new PCubedEzScoreRequest(requests);

        public IEnumerable<KeyValuePair<DataProviderName, Func<ICollection<IAmRequestField>, IHaveUser, string, IAmDataProviderRequest>>> RequestTypes
        {
            get { return _requestTypes; }
        }
    }

    public class RgtVinLaceReqeust : IAmRgtVinRequest
    {
        public RgtVinLaceReqeust(ICollection<IAmRequestField> requestFields)
        {
            VinNumber = requestFields.GetRequestField<IAmVinNumberRequestField>();
        }

        public IAmVinNumberRequestField VinNumber { get; private set; }
    }
    public class RgtLaceRequest : IAmRgtRequest
    {
        public RgtLaceRequest(ICollection<IAmRequestField> requestFields)
        {
            CarId = requestFields.GetRequestField<IAmCarIdRequestField>();
        }

        public IAmCarIdRequestField CarId { get; private set; }
    }
    public class IvidTitleHolderLaceRequest : IAmIvidTitleholderRequest
    {
        public IvidTitleHolderLaceRequest(ICollection<IAmRequestField> requestFields, IHaveUser user)
        {
            RequesterName = new RequesterNameRequestField(user.UserFirstName);
            RequesterEmail = new RequesterEmailRequestField(user.UserName);
            VinNumber = requestFields.GetRequestField<IAmVinNumberRequestField>();
        }

        public IAmRequesterNameRequestField RequesterName { get; private set; }

        public IAmRequesterPhoneRequestField RequesterPhone { get; private set; }

        public IAmRequesterEmailRequestField RequesterEmail { get; private set; }

        public IAmVinNumberRequestField VinNumber { get; private set; }
    }
    public class LightstoneAutoLaceRequest : IAmLightstoneAutoRequest
    {
        public LightstoneAutoLaceRequest(ICollection<IAmRequestField> requestFields)
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
    public class LightstonePropertyLaceRequest : IAmLightstonePropertyRequest
    {
        public LightstonePropertyLaceRequest(ICollection<IAmRequestField> requestFields)
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
    public class IvidLaceRequest : IAmIvidStandardRequest
    {
        public IvidLaceRequest(ICollection<IAmRequestField> requestFields, string pacakgeName, IHaveUser user)
        {
            LicenceNumber = requestFields.GetRequestField<IAmLicenceNumberRequestField>();
            VinNumber = requestFields.GetRequestField<IAmVinNumberRequestField>();
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

    public static class RequestFieldExtensions
    {
        public static T GetRequestField<T>(this ICollection<IAmRequestField> requestFields)
        {
            return requestFields.OfType<T>().Any() ? requestFields.OfType<T>().First() : default(T);
        }
    }
}