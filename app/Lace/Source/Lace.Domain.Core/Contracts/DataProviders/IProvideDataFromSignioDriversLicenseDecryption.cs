using Lace.Domain.Core.Contracts.DataProviders.DriversLicense;
using Lace.Domain.Core.Contracts.Requests;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideDataFromSignioDriversLicenseDecryption : IPointToLaceProvider, IProvideCriticalFailure
    {
        IAmSignioDriversLicenseDecryptionRequest Request { get; }
        IRespondWithDriversLicenseCard DrivingLicense { get; }
        string DecodedData { get; }
    }
}
