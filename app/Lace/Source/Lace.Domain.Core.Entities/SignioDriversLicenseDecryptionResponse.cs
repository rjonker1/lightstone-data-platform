using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.DriversLicense;
using Lace.Domain.Core.Entities.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class SignioDriversLicenseDecryptionResponse : IProvideDataFromSignioDriversLicenseDecryption
    {
        public SignioDriversLicenseDecryptionResponse()
        {
            ResponseState = DataProviderResponseState.NoRecords;
            DrivingLicense = new DrivingLicenseCard();
            DecodedData = string.Empty;
        }

        public static SignioDriversLicenseDecryptionResponse Empty()
        {
            return new SignioDriversLicenseDecryptionResponse();
        }

        public SignioDriversLicenseDecryptionResponse(IRespondWithDriversLicenseCard driversLicense, string decodedData)
        {
            DrivingLicense = driversLicense;
            DecodedData = decodedData;
        }

        private SignioDriversLicenseDecryptionResponse(DataProviderResponseState state)
        {
            ResponseState = state;
            DrivingLicense = new DrivingLicenseCard();
            DecodedData = string.Empty;
        }

        public static SignioDriversLicenseDecryptionResponse WithState(DataProviderResponseState state)
        {
            return new SignioDriversLicenseDecryptionResponse(state);
        }

        public void AddResponseState(DataProviderResponseState state)
        {
            ResponseState = state;
        }

        [DataMember]
        public DataProviderResponseState ResponseState { get; private set; }

        [DataMember]
        public string ResponseStateMessage { get { return ResponseState.Description(); } }


        [DataMember]
        public IAmSignioDriversLicenseDecryptionRequest Request { get; private set; }

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

        [DataMember]
        public bool Handled { get; private set; }

        public void HasNotBeenHandled()
        {
            Handled = false;
        }

        public void HasBeenHandled()
        {
            Handled = true;
        }
    }
}