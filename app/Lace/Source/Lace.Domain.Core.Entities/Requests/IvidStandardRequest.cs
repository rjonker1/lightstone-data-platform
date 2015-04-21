using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Domain.Core.Entities.Requests
{
    public class IvidStandardRequest : IAmDataProviderStandardIvidRequest
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
    }
}