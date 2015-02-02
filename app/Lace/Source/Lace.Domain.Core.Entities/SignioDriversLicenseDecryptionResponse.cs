using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.DriversLicense;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class SignioDriversLicenseDecryptionResponse : IProvideDataFromSignioDriversLicenseDecryption
    {
        public SignioDriversLicenseDecryptionResponse(IRespondWithDriversLicenseCard driversLicense, string decodedData)
        {
            DrivingLicense = driversLicense;
            DecodedData = decodedData;
        }

        [DataMember]
        public IRespondWithDriversLicenseCard DrivingLicense { get; private set; }

        [DataMember]
        public string DecodedData { get; private set; }

        [DataMember]
        public System.Type Type
        {
            get { return GetType(); }
        }

        [DataMember]
        public string TypeName
        {
            get { return GetType().Name; }
        }
    }
}
