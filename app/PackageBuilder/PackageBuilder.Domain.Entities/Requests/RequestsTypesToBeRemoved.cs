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

        private static readonly Func<ICollection<IAmRequestField>,IHaveUser,string,IAmDataProviderRequest> LightstoneProperty =
            (requests,user,packageName) => new LightstonePropertyLaceRequest(requests);

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
            UserId = new UserIdRequestField("5a7222e1-ee65-433b-b673-827319e89cbb");
            IdentityNumber = requestFields.GetRequestField<IAmIdentityNumberRequestField>();
            TrackingNumber = new TrackingNumberRequestField(Guid.NewGuid().ToString());
            MaxRowsToReturn = new MaxRowsToReturnRequestField("1");
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

    public static class RequestFieldExtensions
    {
        public static T GetRequestField<T>(this ICollection<IAmRequestField> requestFields)
        {
            return requestFields.OfType<T>().Any() ? requestFields.OfType<T>().First() : default(T);
        }
    }
}
