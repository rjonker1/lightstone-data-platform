using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Domain.Core.Entities.Requests
{
    public class IvidStandardRequest : IAmStandardIvidRequest
    {
        public IAmRequesterNameRequestField RequesterName { get; private set; }
        public IAmRequesterPhoneRequestField RequesterPhone { get; private set; }
        public IAmRequesterEmailRequestField RequesterEmail { get; private set; }
        public IAmRequestReferenceRequestField RequestReference { get; private set; }
        public IAmApplicantNameRequestField ApplicantName { get; private set; }
        public IAmReasonForApplicationRequestField ReasonForApplication { get; private set; }
        public IAmLabelRequestField Label { get; private set; }
        public IAmEngineNumberRequestField EngineNumber { get; private set; }
        public IAmRegisterNumberRequestField RegisterNumber { get; private set; }
        public IAmLicenseNumberRequestField LicenseNumber { get; private set; }
        public IAmMakeRequestField Make { get; private set; }

        public IvidStandardRequest(IAmRequesterNameRequestField requesterName, IAmRequesterPhoneRequestField requesterPhone, IAmRequesterEmailRequestField requesterEmail, 
            IAmRequestReferenceRequestField requestReference, IAmApplicantNameRequestField applicantName, IAmReasonForApplicationRequestField reasonForApplication, 
            IAmLabelRequestField label, IAmEngineNumberRequestField engineNumber, IAmRegisterNumberRequestField registerNumber, IAmLicenseNumberRequestField licenseNumber, IAmMakeRequestField make)
        {
            RequesterName = requesterName;
            RequesterPhone = requesterPhone;
            RequesterEmail = requesterEmail;
            RequestReference = requestReference;
            ApplicantName = applicantName;
            ReasonForApplication = reasonForApplication;
            Label = label;
            EngineNumber = engineNumber;
            RegisterNumber = registerNumber;
            LicenseNumber = licenseNumber;
            Make = make;
        }
    }
}