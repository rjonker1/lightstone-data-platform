using System.Collections.ObjectModel;
using Api.Domain.Verification.Infrastructure.Dto;
using Api.Tests.Helper.Fakes.Verification;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;

namespace Api.Tests.Helper.Builder
{
    public class DriversLicenseScanBuilder
    {
        public Collection<IPointToLaceProvider> ForDriversLicenseResponseFromLace()
        {
            return new Collection<IPointToLaceProvider>()
            {
                new SignioDriversLicenseDecryptionResponse(new Lace.Domain.Core.Entities.DrivingLicenseCard(),
                    string.Empty)
            };
        }

        public static DriversLicenseResponseDto ForDriversLicenseResponse()
        {
            return new FakeDriversLicenseScanResponse().Response;
        }

        public static DriversLicenseRequestDto ForDriversLicenseRequest()
        {
            return new FakeDriversLicenseRequest().Request;
        }

        public static string ForDriversLicenseScanAsBase64String()
        {
            return FakeDriversLicenseScan.GetBase64String();
        }
    }
}
