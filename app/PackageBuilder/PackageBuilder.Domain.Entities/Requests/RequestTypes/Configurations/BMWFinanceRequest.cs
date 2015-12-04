using System.Collections.Generic;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace PackageBuilder.Domain.Entities.Requests.RequestTypes.Configurations
{
    public class BmwFinanceRequest : IAmBmwFinanceRequest
    {
        public BmwFinanceRequest(ICollection<IAmRequestField> requestFields)
        {
            AccountNumber = requestFields.GetRequestField<IAmAccountNumberRequestField>();
            VinNumber = requestFields.GetRequestField<IAmVinNumberRequestField>();
            IdNumber = requestFields.GetRequestField<IAmIdentityNumberRequestField>();
            LicenceNumber = requestFields.GetRequestField<IAmLicenceNumberRequestField>();
            EngineNumber = requestFields.GetRequestField<IAmEngineNumberRequestField>();
        }

        public IAmAccountNumberRequestField AccountNumber { get; private set; }
        public IAmVinNumberRequestField VinNumber { get; private set; }
        public IAmIdentityNumberRequestField IdNumber { get; private set; }
        public IAmLicenceNumberRequestField LicenceNumber { get; private set; }
        public IAmEngineNumberRequestField EngineNumber { get; private set; }
    }
}
