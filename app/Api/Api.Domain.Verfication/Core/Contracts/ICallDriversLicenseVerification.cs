using Lace.Domain.Core.Requests.Contracts;

namespace Api.Domain.Verification.Core.Contracts
{
    public interface ICallDriversLicenseVerification
    {
        IHaveDriversLicenseResponse DecodeDriversLincenseFromScan(IPointToLaceRequest request);
    }
}
