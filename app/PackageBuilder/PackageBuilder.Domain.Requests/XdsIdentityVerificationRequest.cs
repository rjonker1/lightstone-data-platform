using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Requests
{
    public class XdsIdentityVerificationRequest : IAmXdsIdentificationVerificationRequest
    {
        public XdsIdentityVerificationRequest(IAmIdentityNumberRequestField idNumber, IAmFirstNameRequestField firstName,IAmSurnameRequestField surname, IAmRequestReferenceRequestField reference, IAmVoucherCodeRequestField voucher)
        {
            IdNumber = idNumber;
            FirstName = firstName;
            Surname = surname;
            ReferenceNumber = reference;
            Voucher = voucher;
        }

        public IAmIdentityNumberRequestField IdNumber { get; private set; }
        public IAmFirstNameRequestField FirstName { get; private set; }
        public IAmSurnameRequestField Surname { get; private set; }
        public IAmRequestReferenceRequestField ReferenceNumber { get; private set; }
        public IAmVoucherCodeRequestField Voucher { get; private set; }
    }
}