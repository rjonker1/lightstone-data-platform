using Lace.Test.Helper.Mothers.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Test.Helper.Fakes.RequestTypes
{
    public class IvidStandardRequest : IAmIvidStandardRequest
    {

        public IvidStandardRequest(string licensePlateNumber, string applicantName,
            string packageName, string requestorEmail, string requestorName, string requestorPhone)
        {
            LicenceNumber = LicenceNumberField.Get(licensePlateNumber);
            ApplicantName = ApplicatonNameField.Get(applicantName);
            Label = PackageNameField.Get(packageName);
            RequesterEmail = EmailField.Get(requestorEmail);
            RequesterName = RequestorNameField.Get(requestorName);
            RequesterPhone = RequesterPhoneField.Get(requestorPhone);
        }

        public IAmApplicantNameRequestField ApplicantName { get; private set; }

        public IAmChassisNumberRequestField ChassisNumber { get; private set; }

        public IAmEngineNumberRequestField EngineNumber { get; private set; }

        public IAmLabelRequestField Label { get; private set; }

        public IAmLicenceNumberRequestField LicenceNumber { get; private set; }

        public IAmMakeRequestField Make { get; private set; }

        public IAmReasonForApplicationRequestField ReasonForApplication { get; private set; }

        public IAmRegisterNumberRequestField RegisterNumber { get; private set; }
        public IAmRequestReferenceRequestField RequestReference { get; private set; }

        public IAmRequesterEmailRequestField RequesterEmail { get; private set; }

        public IAmRequesterNameRequestField RequesterName { get; private set; }

        public IAmRequesterPhoneRequestField RequesterPhone { get; private set; }

        public IAmVinNumberRequestField VinNumber { get; private set; }
    }
}
