using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses.Ivid
{
    public class VehicleSpecificInformationBuilder
    {
        private string _odometer;
        private string _color;
        private string _registrationNumber;
        private string _vinNumber;
        private string _licenseNumber;
        private string _engineNumber;
        private string _categoryDescription;

        public IProvideVehicleSpecificInformation Build()
        {
            return new VehicleSpecificInformation(_odometer, _color, _registrationNumber, _vinNumber, _licenseNumber, _engineNumber, _categoryDescription);
        }

        public VehicleSpecificInformationBuilder With(string odometer, string color, string registrationNumber, string vinNumber,
            string licenseNumber,
            string engineNumber, string categoryDescription)
        {
            _odometer = odometer;
            _color = color;
            _registrationNumber = registrationNumber;
            _vinNumber = vinNumber;
            _licenseNumber = licenseNumber;
            _engineNumber = engineNumber;
            _categoryDescription = categoryDescription;
            return this;
        }
    }
}