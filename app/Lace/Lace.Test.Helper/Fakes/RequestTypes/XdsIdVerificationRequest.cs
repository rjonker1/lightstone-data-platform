using Lace.Test.Helper.Mothers.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Test.Helper.Fakes.RequestTypes
{
    public class XdsIdVerificationRequest : IAmXdsIdentificationVerificationRequest
    {
        private XdsIdVerificationRequest(string idNumber)
        {
            IdNumber = IdentityNumberRequestField.Get(idNumber);
        }

        public static XdsIdVerificationRequest WithIdNumber(string idNumber)
        {
            return new XdsIdVerificationRequest(idNumber);
        }
     
        public IAmIdentityNumberRequestField IdNumber { get; private set; }

        public IAmFirstNameRequestField FirstName { get; private set; }

        public IAmRequestReferenceRequestField ReferenceNumber { get; private set; }

        public IAmSurnameRequestField Surname { get; private set; }

        public IAmVoucherCodeRequestField Voucher { get; private set; }
    }
}
