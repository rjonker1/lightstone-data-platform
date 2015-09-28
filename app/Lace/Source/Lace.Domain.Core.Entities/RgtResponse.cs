using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class RgtResponse : IProvideDataFromRgt
    {
        public RgtResponse()
        {
        }

        private RgtResponse(string message)
        {
            HasCriticalFailure = true;
            CriticalFailureMessage = message;
        }

        public static RgtResponse Empty()
        {
            return new RgtResponse();
        }

        public static RgtResponse Failure(string message)
        {
            return new RgtResponse(message);
        }

        //public RgtResponse(string manufacturer, int modelYear, string modelType, string topSpeed, string kilowatts, string fuelEconomy,
        //    string acceleration, string torque, string emissions,
        //    string engineSize, string bodyShape, string fuelType, string transmissionType, string carFullName,
        //    string colour, string rainSensorWipers, string headsUpDisplay,
        //    string vehicleType, string model, string make, string carType)
        //{
        //    Manufacturer = manufacturer;
        //    ModelYear = modelYear;
        //    ModelType = modelType;
        //    TopSpeed = topSpeed;
        //    Kilowatts = kilowatts;
        //    FuelEconomy = fuelEconomy;
        //    Acceleration = acceleration;
        //    Torque = torque;
        //    Emissions = emissions;
        //    EngineSize = engineSize;
        //    BodyShape = bodyShape;
        //    FuelType = fuelType;
        //    TransmissionType = transmissionType;
        //    CarFullname = carFullName;
        //    Colour = colour;
        //    RainSensorWindscreenWipers = rainSensorWipers;
        //    HeadUpDisplay = headsUpDisplay;
        //    VehicleType = vehicleType;
        //    Model = model;
        //    Make = make;
        //    CarType = carType;
        //}

        public RgtResponse(string manufacturer, int modelYear, string modelType, string topSpeed, string kilowatts, string fuelEconomy, 
            string acceleration, string torque, string emissions, string engineSize, string bodyShape, string fuelType, 
            string transmissionType, string carFullname, string colour, string rainSensorWindscreenWipers, string headUpDisplay,
            string vehicleType, string model, string make, string carType, string airConditioner, string electricMirrors, 
            string foldAwayMirrors, string heatedSideMirrors, string doors, string boreXStroke, string compressionRatio, 
            string cylinders, string valvesPerCylinder, string absBrakes, string brakesFrontDiscs, string brakesRearDiscs, 
            string fogLampsFront, string headlightType, string heatedRearWindow, string rearWiper, string powerSteering, 
            string colourCodedBumpers, string colourCodedDoorHandles, string colourCodedMirrors, string maintenancePlanKms, 
            string maintenancePlanYears, string serviceIntervalsKms, string servicePlanKms, string servicePlanYears, 
            string warrantyKms, string warrantyYears, string rimSizeFront, string tyreSizeFront, string tyreSizeRear, 
            string wheelType)
        {
            Manufacturer = manufacturer;
            ModelYear = modelYear;
            ModelType = modelType;
            TopSpeed = topSpeed;
            Kilowatts = kilowatts;
            FuelEconomy = fuelEconomy;
            Acceleration = acceleration;
            Torque = torque;
            Emissions = emissions;
            EngineSize = engineSize;
            BodyShape = bodyShape;
            FuelType = fuelType;
            TransmissionType = transmissionType;
            CarFullname = carFullname;
            Colour = colour;
            RainSensorWindscreenWipers = rainSensorWindscreenWipers;
            HeadUpDisplay = headUpDisplay;
            VehicleType = vehicleType;
            Model = model;
            Make = make;
            CarType = carType;
            AirConditioner = airConditioner;
            ElectricMirrors = electricMirrors;
            FoldAwayMirrors = foldAwayMirrors;
            HeatedSideMirrors = heatedSideMirrors;
            Doors = doors;
            BoreXStroke = boreXStroke;
            CompressionRatio = compressionRatio;
            Cylinders = cylinders;
            ValvesPerCylinder = valvesPerCylinder;
            ABSBrakes = absBrakes;
            BrakesFrontDiscs = brakesFrontDiscs;
            BrakesRearDiscs = brakesRearDiscs;
            FogLampsFront = fogLampsFront;
            HeadlightType = headlightType;
            HeatedRearWindow = heatedRearWindow;
            RearWiper = rearWiper;
            PowerSteering = powerSteering;
            ColourCodedBumpers = colourCodedBumpers;
            ColourCodedDoorHandles = colourCodedDoorHandles;
            ColourCodedMirrors = colourCodedMirrors;
            MaintenancePlanKms = maintenancePlanKms;
            MaintenancePlanYears = maintenancePlanYears;
            ServiceIntervalsKms = serviceIntervalsKms;
            ServicePlanKms = servicePlanKms;
            ServicePlanYears = servicePlanYears;
            WarrantyKms = warrantyKms;
            WarrantyYears = warrantyYears;
            RimSizeFront = rimSizeFront;
            TyreSizeFront = tyreSizeFront;
            TyreSizeRear = tyreSizeRear;
            WheelType = wheelType;
        }

        [DataMember]
        public IAmRgtRequest Request { get; set; }

        [DataMember]
        public string Manufacturer { get; private set; }

        [DataMember]
        public int ModelYear { get; private set; }

        [DataMember]
        public string ModelType { get; private set; }

        [DataMember]
        public string TopSpeed { get; private set; }

        [DataMember]
        public string Kilowatts { get; private set; }

        [DataMember]
        public string FuelEconomy { get; private set; }

        [DataMember]
        public string Acceleration { get; private set; }

        [DataMember]
        public string Torque { get; private set; }

        [DataMember]
        public string Emissions { get; private set; }

        [DataMember]
        public string EngineSize { get; private set; }

        [DataMember]
        public string BodyShape { get; private set; }

        [DataMember]
        public string FuelType { get; private set; }

        [DataMember]
        public string TransmissionType { get; private set; }

        [DataMember]
        public string CarFullname { get; private set; }

        [DataMember]
        public string Colour { get; private set; }

        [DataMember]
        public string RainSensorWindscreenWipers { get; private set; }

        [DataMember]
        public string HeadUpDisplay { get; private set; }

        [DataMember]
        public string VehicleType { get; private set; }

        [DataMember]
        public string Model { get; private set; }

        [DataMember]
        public string Make { get; private set; }

        [DataMember]
        public string CarType { get; private set; }

        [DataMember]
        public string AirConditioner { get; private set; }

        [DataMember]
        public string ElectricMirrors { get; private set; }

        [DataMember]
        public string FoldAwayMirrors { get; private set; }

        [DataMember]
        public string HeatedSideMirrors { get; private set; }

        [DataMember]
        public string Doors { get; private set; }

        [DataMember]
        public string BoreXStroke { get; private set; }

        [DataMember]
        public string CompressionRatio { get; private set; }

        [DataMember]
        public string Cylinders { get; private set; }

        [DataMember]
        public string ValvesPerCylinder { get; private set; }

        [DataMember]
        public string ABSBrakes { get; private set; }

        [DataMember]
        public string BrakesFrontDiscs { get; private set; }

        [DataMember]
        public string BrakesRearDiscs { get; private set; }

        [DataMember]
        public string FogLampsFront { get; private set; }

        [DataMember]
        public string HeadlightType { get; private set; }

        [DataMember]
        public string HeatedRearWindow { get; private set; }

        [DataMember]
        public string RearWiper { get; private set; }

        [DataMember]
        public string PowerSteering { get; private set; }

        [DataMember]
        public string ColourCodedBumpers { get; private set; }

        [DataMember]
        public string ColourCodedDoorHandles { get; private set; }

        [DataMember]
        public string ColourCodedMirrors { get; private set; }

        [DataMember]
        public string MaintenancePlanKms { get; private set; }

        [DataMember]
        public string MaintenancePlanYears { get; private set; }

        [DataMember]
        public string ServiceIntervalsKms { get; private set; }

        [DataMember]
        public string ServicePlanKms { get; private set; }

        [DataMember]
        public string ServicePlanYears { get; private set; }

        [DataMember]
        public string WarrantyKms { get; private set; }

        [DataMember]
        public string WarrantyYears { get; private set; }

        [DataMember]
        public string RimSizeFront { get; private set; }

        [DataMember]
        public string TyreSizeFront { get; private set; }

        [DataMember]
        public string TyreSizeRear { get; private set; }

        [DataMember]
        public string WheelType { get; private set; }

        [DataMember]
        public string TypeName
        {
            get { return GetType().Name; }
        }

        [DataMember]
        public Type Type
        {
            get { return GetType(); }
        }

        [DataMember]
        public bool Handled { get; private set; }

        [DataMember]
        public bool HasCriticalFailure { get; private set; }

        [DataMember]
        public string CriticalFailureMessage { get; private set; }

        public void HasNotBeenHandled()
        {
            Handled = false;
        }

        public void HasBeenHandled()
        {
            Handled = true;
        }
    }
}