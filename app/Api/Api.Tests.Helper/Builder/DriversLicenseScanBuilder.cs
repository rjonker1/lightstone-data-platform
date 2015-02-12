using Api.Domain.Verification.Infrastructure.Dto;
using Api.Tests.Helper.Fakes.Verification;
using Lace.Domain.Core.Entities;
using Lace.Domain.Infrastructure.Core.Dto;

namespace Api.Tests.Helper.Builder
{
    public class DriversLicenseScanBuilder
    {
        public LaceExternalSourceResponse ForDriversLicenseResponseFromLace()
        {
            return new LaceExternalSourceResponse()
            {
                Response = new LaceResponse()
                {
                    SignioDriversLicenseDecryptionResponse =
                        new SignioDriversLicenseDecryptionResponse(new Lace.Domain.Core.Entities.DrivingLicenseCard(),
                            string.Empty),
                    SignioDriversLicenseDecryptionResponseHandled = new SignioDriversLicenseDecryptionResponseHandled()
                }
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
