using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests.RequestsPB;

namespace PackageBuilder.Domain.Requests
{
    public class IvidStandardRequest : IAmIvidStandardRequestPb
    {
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

        public IvidStandardRequest( IAmEngineNumberRequestField engineNumber, IAmChassisNumberRequestField chassisNumber, IAmVinNumberRequestField vinNumber, IAmLicenceNumberRequestField licenceNumber, IAmRegisterNumberRequestField registerNumber, IAmMakeRequestField make)
        {
            EngineNumber = engineNumber;
            ChassisNumber = chassisNumber;
            VinNumber = vinNumber;
            LicenceNumber = licenceNumber;
            RegisterNumber = registerNumber;
            Make = make;
        }
    }
}