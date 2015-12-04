using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Requests
{
   public  class XdsIdentityVerificationRequest : IAmXdsIdentificationVerificationRequest
    {
       public XdsIdentityVerificationRequest(IAmIdentityNumberRequestField idNumber, IAmCellularNumberRequestField cellularNumber,
           IAmAccountNumberRequestField accountNumber)
        {
            IdNumber = idNumber;
            CellularNumber = cellularNumber;
            AccountNumber = accountNumber;
        }

       public IAmIdentityNumberRequestField IdNumber { get; private set; }
       public IAmCellularNumberRequestField CellularNumber { get; private set; }
       public IAmAccountNumberRequestField AccountNumber { get; private set; }
    }
}
