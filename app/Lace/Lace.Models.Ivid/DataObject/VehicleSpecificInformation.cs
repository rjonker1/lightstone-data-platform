using Lace.Models.Responses.Sources;

namespace Lace.Models.Ivid.DataObject
{
    public class VehicleSpecificInformation : IProvideVehicleSpecificInformation
    {
        public VehicleSpecificInformation(string odometer, string color, string registrationNumber, string vinNumber,
            string licenseNumber,
            string engineNumber, string categoryDescription)
        {
            Odometer = odometer;
            Colour = color;
            RegistrationNumber = registrationNumber;
            VinNumber = vinNumber;
            LicenseNumber = licenseNumber;
            EngineNumber = engineNumber;
            CategoryDescription = categoryDescription;
        }

        public string Odometer { get; private set; }

        public string Colour { get; private set; }

        public string RegistrationNumber { get; private set; }

        public string VinNumber { get; private set; }

        public string LicenseNumber { get; private set; }

        public string EngineNumber { get; private set; }

        public string CategoryDescription { get; private set; }
    }
}
