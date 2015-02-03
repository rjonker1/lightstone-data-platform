using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.DriversLicense;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Extensions;

namespace Lace.Domain.DataProviders.Signio.DriversLicense.Infrastructure.Management
{
    public class TransformSignioResponse : ITransformResponseFromDataProvider
    {
        public string Message { get; private set; }
        public IProvideDataFromSignioDriversLicenseDecryption Result { get; private set; }

        public bool Continue { get; private set; }

        public TransformSignioResponse(string response)
        {
            Continue = !string.IsNullOrWhiteSpace(response);
            Message = response;
        }

        public void Transform()
        {
            var driversLicenseCard = Message.XmlToObject<DrivingLicenseCard>();
            Result = new SignioDriversLicenseDecryptionResponse(driversLicenseCard, Message);
        }
    }
}
