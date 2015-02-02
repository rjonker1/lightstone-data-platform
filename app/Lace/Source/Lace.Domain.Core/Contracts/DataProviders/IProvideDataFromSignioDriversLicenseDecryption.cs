using Lace.Domain.Core.Contracts.DataProviders.DriversLicense;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideDataFromSignioDriversLicenseDecryption : IPointToLaceProvider
    {
        IRespondWithDriversLicenseCard DrivingLicense { get; }
        string DecodedData { get; }
    }
}
