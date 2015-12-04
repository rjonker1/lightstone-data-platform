using System.Runtime.Serialization;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace DataProviders.Xds.IdentityVerification.Infrastructure.Dto
{
    [DataContract]
    public sealed class IdentityVerificationRequest
    {
        private readonly IAmXdsIdentificationVerificationRequest _request;

        public IdentityVerificationRequest()
        {

        }

        public IdentityVerificationRequest(IAmXdsIdentificationVerificationRequest request)
        {
            _request = request;
        }

        public IdentityVerificationRequest Map()
        {
            IdNumber = _request.IdNumber.GetValue();
            FirstName = _request.FirstName.GetValue();
            Surname = _request.Surname.GetValue();
            ReferenceNumber = _request.ReferenceNumber.GetValue();
            VoucherCode = _request.Voucher.GetValue();
            return this;
        }

        public IdentityVerificationRequest Validate()
        {
            IsValid = !string.IsNullOrEmpty(IdNumber) || ValidIdNumber();
            return this;
        }

        private bool ValidIdNumber()
        {
            long id;
            long.TryParse(IdNumber, out id);
            return id > 0;
        }

        [DataMember]
        public string IdNumber { get; private set; }

        [DataMember]
        public string FirstName { get; private set; }

        [DataMember]
        public string Surname { get; private set; }
        [DataMember]
        public string ReferenceNumber { get; private set; }
        [DataMember]
        public string VoucherCode { get; private set; }

        [DataMember]
        public bool IsValid { get; private set; }
    }
}