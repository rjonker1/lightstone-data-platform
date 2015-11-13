using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses
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
        public string _airConditioner { get; set; }
        public string _electricMirrors { get; set; }
        public string _foldAwayMirrors { get; private set; }
        public string _heatedSideMirrors { get; private set; }
        public string _doors { get; private set; }
        public string _boreXStroke { get; private set; }
        public string _compressionRatio { get; private set; }
        public string _cylinders { get; private set; }
        public string _valvesPerCylinder { get; private set; }
        public string _absBrakes { get; private set; }
        public string _brakesFrontDiscs { get; private set; }
        public string _brakesRearDiscs { get; private set; }
        public string _fogLampsFront { get; private set; }
        public string _headlightType { get; private set; }
        public string _heatedRearWindow { get; private set; }
        public string _rearWiper { get; private set; }
        public string _powerSteering { get; private set; }
        public string _colourCodedBumpers { get; private set; }
        public string _colourCodedDoorHandles { get; private set; }
        public string _colourCodedMirrors { get; private set; }
        public string _maintenancePlanKms { get; private set; }
        public string _maintenancePlanYears { get; private set; }
        public string _serviceIntervalsKms { get; private set; }
        public string _servicePlanKms { get; private set; }
        public string _servicePlanYears { get; private set; }
        public string _warrantyKms { get; private set; }
        public string _warrantyYears { get; private set; }
        public string _rimSizeFront { get; private set; }
        public string _tyreSizeFront { get; private set; }
        public string _tyreSizeRear { get; private set; }
        public string _wheelType { get; private set; }

        public IProvideDataFromRgt Build()
        {
            return new RgtResponse(_manufacturer, _modelYear, _modelType, _topSpeed, _kilowatts, _fuelEconomy,
                _acceleration, _torque, _emissions,
                _engineSize, _bodyShape, _fuelType, _transmissionType, _carFullname,
                _colour, _rainSensorWindscreenWipers, _headUpDisplay,
                _vehicleType, _model, _make, _carType, _airConditioner, _electricMirrors, _foldAwayMirrors, _heatedSideMirrors,
                _doors,_boreXStroke, _compressionRatio, _cylinders, _valvesPerCylinder, _absBrakes, _brakesFrontDiscs, _brakesRearDiscs,
                _fogLampsFront, _headlightType, _heatedRearWindow, _rearWiper, _powerSteering, _colourCodedBumpers, _colourCodedDoorHandles,
                _colourCodedMirrors, _maintenancePlanKms, _maintenancePlanYears, _serviceIntervalsKms, _serviceIntervalsKms, _servicePlanYears, 
                _warrantyKms, _warrantyYears, _rimSizeFront, _tyreSizeFront, _tyreSizeRear, _wheelType);
        }

        //public RgtResponseBuilder With(string manufacturer, int modelYear, string modelType, string topSpeed, string kilowatts, string fuelEconomy,
        //    string acceleration, string torque, string emissions,
        //    string engineSize, string bodyShape, string fuelType, string transmissionType, string carFullName,
        //    string colour, string rainSensorWipers, string headsUpDisplay,
        //    string vehicleType, string model, string make, string carType)
        //{
        //    _manufacturer = manufacturer;
        //    _modelYear = modelYear;
        //    _modelType = modelType;
        //    _topSpeed = topSpeed;
        //    _kilowatts = kilowatts;
        //    _fuelEconomy = fuelEconomy;
        //    _acceleration = acceleration;
        //    _torque = torque;
        //    _emissions = emissions;
        //    _engineSize = engineSize;
        //    _bodyShape = bodyShape;
        //    _fuelType = fuelType;
        //    _transmissionType = transmissionType;
        //    _carFullname = carFullName;
        //    _colour = colour;
        //    _rainSensorWindscreenWipers = rainSensorWipers;
        //    _headUpDisplay = headsUpDisplay;
        //    _vehicleType = vehicleType;
        //    _model = model;
        //    _make = make;
        //    _carType = carType;
        //    return this;
        //}

        public RgtResponseBuilder With(string manufacturer, int modelYear, string modelType, string topSpeed, string kilowatts, string fuelEconomy, 
            string acceleration, string torque, string emissions, string engineSize, string bodyShape, string fuelType, string transmissionType, 
            string carFullname, string colour, string rainSensorWindscreenWipers, string headUpDisplay, string vehicleType, string model, 
            string make, string carType, string airConditioner, string electricMirrors, string foldAwayMirrors, string heatedSideMirrors, 
            string doors, string boreXStroke, string compressionRatio, string cylinders, string valvesPerCylinder, string absBrakes, 
            string brakesFrontDiscs, string brakesRearDiscs, string fogLampsFront, string headlightType, string heatedRearWindow, 
            string rearWiper, string powerSteering, string colourCodedBumpers, string colourCodedDoorHandles, string colourCodedMirrors, 
            string maintenancePlanKms, string maintenancePlanYears, string serviceIntervalsKms, string servicePlanKms, 
            string servicePlanYears, string warrantyKms, string warrantyYears, string rimSizeFront, string tyreSizeFront, 
            string tyreSizeRear, string wheelType)
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
            _carFullname = carFullname;
            _colour = colour;
            _rainSensorWindscreenWipers = rainSensorWindscreenWipers;
            _headUpDisplay = headUpDisplay;
            _vehicleType = vehicleType;
            _model = model;
            _make = make;
            _carType = carType;
            _airConditioner = airConditioner;
            _electricMirrors = electricMirrors;
            _foldAwayMirrors = foldAwayMirrors;
            _heatedSideMirrors = heatedSideMirrors;
            _doors = doors;
            _boreXStroke = boreXStroke;
            _compressionRatio = compressionRatio;
            _cylinders = cylinders;
            _valvesPerCylinder = valvesPerCylinder;
            _absBrakes = absBrakes;
            _brakesFrontDiscs = brakesFrontDiscs;
            _brakesRearDiscs = brakesRearDiscs;
            _fogLampsFront = fogLampsFront;
            _headlightType = headlightType;
            _heatedRearWindow = heatedRearWindow;
            _rearWiper = rearWiper;
            _powerSteering = powerSteering;
            _colourCodedBumpers = colourCodedBumpers;
            _colourCodedDoorHandles = colourCodedDoorHandles;
            _colourCodedMirrors = colourCodedMirrors;
            _maintenancePlanKms = maintenancePlanKms;
            _maintenancePlanYears = maintenancePlanYears;
            _serviceIntervalsKms = serviceIntervalsKms;
            _servicePlanKms = servicePlanKms;
            _servicePlanYears = servicePlanYears;
            _warrantyKms = warrantyKms;
            _warrantyYears = warrantyYears;
            _rimSizeFront = rimSizeFront;
            _tyreSizeFront = tyreSizeFront;
            _tyreSizeRear = tyreSizeRear;
            _wheelType = wheelType;
            return this;
        }
    }
}