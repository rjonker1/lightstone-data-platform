using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class SignioDriversLicenseDecryptionResponse
    {
        public Lace.Domain.Core.Entities.SignioDriversLicenseDecryptionResponse DefaultSignioDriversLicenseDecryptionResponse()
        {

            return new Lace.Domain.Core.Entities.SignioDriversLicenseDecryptionResponse(
                    new DrivingLicenseCard(new IdentityDocument(), new Person(), new DrivingLicense(), new Card(),
                        new ProfessionalDrivingPermit(), new VehicleClass(), new VehicleClass(), new VehicleClass(),
                        new VehicleClass(), string.Empty, string.Empty, string.Empty), string.Empty);

        }
    }
}