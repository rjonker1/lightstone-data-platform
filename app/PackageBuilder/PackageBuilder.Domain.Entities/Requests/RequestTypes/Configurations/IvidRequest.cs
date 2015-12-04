using System.Collections.Generic;
using Lace.Domain.Core.Requests.Contracts;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using PackageBuilder.Domain.Requests.Fields;

namespace PackageBuilder.Domain.Entities.Requests.RequestTypes.Configurations
{
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
}
