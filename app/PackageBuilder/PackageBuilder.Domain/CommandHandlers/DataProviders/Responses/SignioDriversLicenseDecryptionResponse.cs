using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class SignioDriversLicenseDecryptionResponse
    {
        public Lace.Domain.Core.Entities.SignioDriversLicenseDecryptionResponse Default()
        {

            var result = new Lace.Domain.Core.Entities.SignioDriversLicenseDecryptionResponse(
                    new DrivingLicenseCard(new IdentityDocument(), new Person(), new DrivingLicense(), new Card(),
                        new ProfessionalDrivingPermit(), new VehicleClass(), new VehicleClass(), new VehicleClass(),
                        new VehicleClass(), string.Empty, string.Empty, string.Empty), string.Empty);
            result.AddResponseState(DataProviderResponseState.NoRecords);
            return result;
        }
    }
}