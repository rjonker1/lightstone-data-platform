using System;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.Core.Entities
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
        public string TypeName
        {
            get
            {
                return GetType().Name;
            }
        }
        public Type Type
        {
            get
            {
                return GetType();
            }
        }
    }
}
