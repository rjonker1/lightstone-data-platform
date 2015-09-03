using System;
namespace Lace.Toolbox.Signio
{
    public class DriversLicenseDecryptionRequest
    {
        public DriversLicenseDecryptionRequest(Guid userId, string driversLicenseScan)
        {
            UserId = userId;
            DriversLicenseScan = driversLicenseScan;
        }
        public readonly Guid UserId;
        public readonly string DriversLicenseScan;
    }
}