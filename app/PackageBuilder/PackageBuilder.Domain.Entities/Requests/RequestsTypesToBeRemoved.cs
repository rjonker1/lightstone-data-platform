using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Requests.Contracts;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using PackageBuilder.Domain.Requests.Fields;

namespace PackageBuilder.Domain.Entities.Requests
{
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

    public class LightstoneAutoLaceReqeust : IAmLightstoneAutoRequest
    {
        public LightstoneAutoLaceReqeust(ICollection<IAmRequestField> requestFields)
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
