using Lace.Domain.Core.Requests.Contracts;
using PackageBuilder.Domain.Entities.Packages.WriteModels;

namespace Api.Verfication.Core.Contracts
{
    public interface ICallDriversLicenseVerification
    {
        IHaveDriversLicenseResponse DecodeDriversLincenseFromScan(ILaceRequest request);
    }
}
