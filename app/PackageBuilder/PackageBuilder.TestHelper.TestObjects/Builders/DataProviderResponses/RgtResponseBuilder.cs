using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Dto;

namespace PackageBuilder.TestHelper.Builders.Builders.DataProviderResponses
{
    public class RgtResponseBuilder
    {
        private string _manufacturer { get; set; }
        private int _modelYear { get; set; }
        private string _modelType { get; set; }
        private string _topSpeed { get; set; }
        private string _kilowatts { get; set; }
        private string _fuelEconomy { get; set; }
        private string _acceleration { get; set; }
        private string _torque { get; set; }
        private string _emissions { get; set; }
        private string _engineSize { get; set; }
        private string _bodyShape { get; set; }
        private string _fuelType { get; set; }
        private string _transmissionType { get; set; }
        private string _carFullname { get; set; }
        private string _colour { get; set; }
        private string _rainSensorWindscreenWipers { get; set; }
        private string _headUpDisplay { get; set; }
        private string _vehicleType { get; set; }
        private string _model { get; set; }
        private string _make { get; set; }
        private string _carType { get; set; }
        public IProvideDataFromRgt Build()
        {
            return new RgtResponse(_manufacturer, _modelYear, _modelType, _topSpeed, _kilowatts, _fuelEconomy,
                _acceleration, _torque, _emissions,
                _engineSize, _bodyShape, _fuelType, _transmissionType, _carFullname,
                _colour, _rainSensorWindscreenWipers, _headUpDisplay,
                _vehicleType, _model, _make, _carType);
        }

        public RgtResponseBuilder With(string manufacturer, int modelYear, string modelType, string topSpeed, string kilowatts, string fuelEconomy,
            string acceleration, string torque, string emissions,
            string engineSize, string bodyShape, string fuelType, string transmissionType, string carFullName,
            string colour, string rainSensorWipers, string headsUpDisplay,
            string vehicleType, string model, string make, string carType)
        {
            _manufacturer = manufacturer;
            _modelYear = modelYear;
            _modelType = modelType;
            _topSpeed = topSpeed;
            _kilowatts = kilowatts;
            _fuelEconomy = fuelEconomy;
            _acceleration = acceleration;
            _torque = torque;
            _emissions = emissions;
            _engineSize = engineSize;
            _bodyShape = bodyShape;
            _fuelType = fuelType;
            _transmissionType = transmissionType;
            _carFullname = carFullName;
            _colour = colour;
            _rainSensorWindscreenWipers = rainSensorWipers;
            _headUpDisplay = headsUpDisplay;
            _vehicleType = vehicleType;
            _model = model;
            _make = make;
            _carType = carType;
            return this;
        }
    }
}