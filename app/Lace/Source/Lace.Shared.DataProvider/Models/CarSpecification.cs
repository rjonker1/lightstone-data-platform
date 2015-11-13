using Lace.Domain.Core.Contracts.Caching;

namespace Lace.Toolbox.Database.Models
{
    public sealed class CarSpecification : IAmCachable
    {
        public const string SelectWithCarId =
            @"select
              distinct c.Car_ID as CarId, c.CarModel, c.ModelYear,m.ManufacturerName, ct.CarTypeName, c.EngineSize, c.BodyShape, c.FuelType, c.TransmissionType, c.CarFullName, 
                  c.RainSensorWindscreenWipers, c.HeadUpDisplay,
                  max(case when SpID.Spec_Desc = 'Air Conditioner' then SpL.Spec_Val end) [AirConditioner],
                  max(case when SpID.Spec_Desc = 'Electric Mirrors' then SpL.Spec_Val end) [ElectricMirrors],
                  max(case when SpID.Spec_Desc = 'Fold Away Mirrors' then SpL.Spec_Val end) [FoldAwayMirrors],
                  max(case when SpID.Spec_Desc = 'Heated Side Mirrors' then SpL.Spec_Val end) [HeatedSideMirrors],
                  max(case when SpID.Spec_Desc = 'Doors' then SpL.Spec_Val end) [Doors],
                  max(case when SpID.Spec_Desc = 'Bore x Stroke (mm)' then SpL.Spec_Val end) [BoreXStroke],
                  max(case when SpID.Spec_Desc = 'Compression Ratio' then SpL.Spec_Val end) [CompressionRatio],
                  max(case when SpID.Spec_Desc = 'Cylinders' then SpL.Spec_Val end) [Cylinders],
                  max(case when SpID.Spec_Desc = 'Valves Per Cylinder' then SpL.Spec_Val end) [ValvesPerCylinder],
                  max(case when SpID.Spec_Desc = 'ABS Brakes' then SpL.Spec_Val end) [ABSBrakes],
                  max(case when SpID.Spec_Desc = 'Brakes - Front Discs' then SpL.Spec_Val end) [BrakesFrontDiscs],
                  max(case when SpID.Spec_Desc = 'Brakes - Rear Discs' then SpL.Spec_Val end) [BrakesRearDiscs],
                  max(case when SpID.Spec_Desc = 'Fog Lamps - Front' then SpL.Spec_Val end) [FogLampsFront],
                  max(case when SpID.Spec_Desc = 'Fog Lamps - Rear' then SpL.Spec_Val end) [FogLampsRear],
                  max(case when SpID.Spec_Desc = 'Headlight Type' then SpL.Spec_Val end) [HeadlightType],
                  max(case when SpID.Spec_Desc = 'Heated Rear Window' then SpL.Spec_Val end) [HeatedRearWindow],
                  max(case when SpID.Spec_Desc = 'Rear Wiper' then SpL.Spec_Val end) [RearWiper],
                  max(case when SpID.Spec_Desc = 'Power Steering' then SpL.Spec_Val end) [PowerSteering],
                  max(case when SpID.Spec_Desc = 'Colour Coded Bumpers' then SpL.Spec_Val end) [ColourCodedBumpers],
                  max(case when SpID.Spec_Desc = 'Colour Coded Door Handles' then SpL.Spec_Val end) [ColourCodedDoorHandles],
                  max(case when SpID.Spec_Desc = 'Colour Coded Mirrors' then SpL.Spec_Val end) [ColourCodedMirrors],
                  max(case when SpID.Spec_Desc = 'Maintenance Plan - km''s' then SpL.Spec_Val end) [MaintenancePlanKms],
                  max(case when SpID.Spec_Desc = 'Maintenance Plan - Years' then SpL.Spec_Val end) [MaintenancePlanYears],
                  max(case when SpID.Spec_Desc = 'Service Intervals - km''s' then SpL.Spec_Val end) [ServiceIntervalsKms],
                  max(case when SpID.Spec_Desc = 'Service Plan - km''s' then SpL.Spec_Val end) [ServicePlanKms],
                  max(case when SpID.Spec_Desc = 'Service Plan - Years' then SpL.Spec_Val end) [ServicePlanYears],
                  max(case when SpID.Spec_Desc = 'Warranty - km''s' then SpL.Spec_Val end) [WarrantyKms],
                  max(case when SpID.Spec_Desc = 'Warranty - Years' then SpL.Spec_Val end) [WarrantyYears],
                  max(case when SpID.Spec_Desc = 'Rim Size - Front' then SpL.Spec_Val end) [RimSizeFront],
                  max(case when SpID.Spec_Desc = 'Tyre Size - Front' then SpL.Spec_Val end) [TyreSizeFront],
                  max(case when SpID.Spec_Desc = 'Tyre Size - Rear' then SpL.Spec_Val end) [TyreSizeRear],
                  max(case when SpID.Spec_Desc = 'Wheel Type' then SpL.Spec_Val end) [WheelType]
            from SpecificationID SpID
	             inner join SpecificationLookup SpL on SpL.Spec_ID = SpID.Spec_ID
	             inner join Car c on c.Car_ID = SpL.Car_ID
	             join Manufacturer m on m.Manufacturer_ID = c.Manufacturer_ID join CarType ct on ct.CarType_ID = c.CarType_ID 
            where SpL.Car_ID = @CarId
            group by c.Car_ID, c.CarModel, c.ModelYear,m.ManufacturerName, ct.CarTypeName, c.EngineSize, c.BodyShape, c.FuelType, c.TransmissionType, c.CarFullName, 
              c.RainSensorWindscreenWipers, c.HeadUpDisplay";
        
        public const string SelectAll =
            @"select
              distinct c.Car_ID as CarId, c.CarModel, c.ModelYear,m.ManufacturerName, ct.CarTypeName, c.EngineSize, c.BodyShape, c.FuelType, c.TransmissionType, c.CarFullName, 
                  c.RainSensorWindscreenWipers, c.HeadUpDisplay,
                  max(case when SpID.Spec_Desc = 'Air Conditioner' then SpL.Spec_Val end) [AirConditioner],
                  max(case when SpID.Spec_Desc = 'Electric Mirrors' then SpL.Spec_Val end) [ElectricMirrors],
                  max(case when SpID.Spec_Desc = 'Fold Away Mirrors' then SpL.Spec_Val end) [FoldAwayMirrors],
                  max(case when SpID.Spec_Desc = 'Heated Side Mirrors' then SpL.Spec_Val end) [HeatedSideMirrors],
                  max(case when SpID.Spec_Desc = 'Doors' then SpL.Spec_Val end) [Doors],
                  max(case when SpID.Spec_Desc = 'Bore x Stroke (mm)' then SpL.Spec_Val end) [BoreXStroke],
                  max(case when SpID.Spec_Desc = 'Compression Ratio' then SpL.Spec_Val end) [CompressionRatio],
                  max(case when SpID.Spec_Desc = 'Cylinders' then SpL.Spec_Val end) [Cylinders],
                  max(case when SpID.Spec_Desc = 'Valves Per Cylinder' then SpL.Spec_Val end) [ValvesPerCylinder],
                  max(case when SpID.Spec_Desc = 'ABS Brakes' then SpL.Spec_Val end) [ABSBrakes],
                  max(case when SpID.Spec_Desc = 'Brakes - Front Discs' then SpL.Spec_Val end) [BrakesFrontDiscs],
                  max(case when SpID.Spec_Desc = 'Brakes - Rear Discs' then SpL.Spec_Val end) [BrakesRearDiscs],
                  max(case when SpID.Spec_Desc = 'Fog Lamps - Front' then SpL.Spec_Val end) [FogLampsFront],
                  max(case when SpID.Spec_Desc = 'Fog Lamps - Rear' then SpL.Spec_Val end) [FogLampsRear],
                  max(case when SpID.Spec_Desc = 'Headlight Type' then SpL.Spec_Val end) [HeadlightType],
                  max(case when SpID.Spec_Desc = 'Heated Rear Window' then SpL.Spec_Val end) [HeatedRearWindow],
                  max(case when SpID.Spec_Desc = 'Rear Wiper' then SpL.Spec_Val end) [RearWiper],
                  max(case when SpID.Spec_Desc = 'Power Steering' then SpL.Spec_Val end) [PowerSteering],
                  max(case when SpID.Spec_Desc = 'Colour Coded Bumpers' then SpL.Spec_Val end) [ColourCodedBumpers],
                  max(case when SpID.Spec_Desc = 'Colour Coded Door Handles' then SpL.Spec_Val end) [ColourCodedDoorHandles],
                  max(case when SpID.Spec_Desc = 'Colour Coded Mirrors' then SpL.Spec_Val end) [ColourCodedMirrors],
                  max(case when SpID.Spec_Desc = 'Maintenance Plan - km''s' then SpL.Spec_Val end) [MaintenancePlanKms],
                  max(case when SpID.Spec_Desc = 'Maintenance Plan - Years' then SpL.Spec_Val end) [MaintenancePlanYears],
                  max(case when SpID.Spec_Desc = 'Service Intervals - km''s' then SpL.Spec_Val end) [ServiceIntervalsKms],
                  max(case when SpID.Spec_Desc = 'Service Plan - km''s' then SpL.Spec_Val end) [ServicePlanKms],
                  max(case when SpID.Spec_Desc = 'Service Plan - Years' then SpL.Spec_Val end) [ServicePlanYears],
                  max(case when SpID.Spec_Desc = 'Warranty - km''s' then SpL.Spec_Val end) [WarrantyKms],
                  max(case when SpID.Spec_Desc = 'Warranty - Years' then SpL.Spec_Val end) [WarrantyYears],
                  max(case when SpID.Spec_Desc = 'Rim Size - Front' then SpL.Spec_Val end) [RimSizeFront],
                  max(case when SpID.Spec_Desc = 'Tyre Size - Front' then SpL.Spec_Val end) [TyreSizeFront],
                  max(case when SpID.Spec_Desc = 'Tyre Size - Rear' then SpL.Spec_Val end) [TyreSizeRear],
                  max(case when SpID.Spec_Desc = 'Wheel Type' then SpL.Spec_Val end) [WheelType]
            from SpecificationID SpID
	             inner join SpecificationLookup SpL on SpL.Spec_ID = SpID.Spec_ID
	             inner join Car c on c.Car_ID = SpL.Car_ID
	             join Manufacturer m on m.Manufacturer_ID = c.Manufacturer_ID join CarType ct on ct.CarType_ID = c.CarType_ID 
            group by c.Car_ID, c.CarModel, c.ModelYear,m.ManufacturerName, ct.CarTypeName, c.EngineSize, c.BodyShape, c.FuelType, c.TransmissionType, c.CarFullName, 
              c.RainSensorWindscreenWipers, c.HeadUpDisplay";

        public CarSpecification()
        {
            
        }

        public CarSpecification(string manufacturerName, int? modelYear, string carTypeName, string topSpeed, string kilowatts,
            string fuelEconomy, string acceleration, string torque, string emissions, string engineSize, string bodyShape,
            string fuelType, string transmissionType, string carFullname, string colour,
            string rainSensorWindscreenWipers, string headUpDisplay, string vehicleType, string carModel, string make,
            string carType, string airConditioner, string electricMirrors, string foldAwayMirrors, string heatedSideMirrors,
            string doors, string boreXStroke, string compressionRatio, string cylinders, string valvesPerCylinder,
            string absBrakes, string brakesFrontDiscs, string brakesRearDiscs, string fogLampsFront, string headlightType,
            string heatedRearWindow, string rearWiper, string powerSteering, string colourCodedBumpers, string colourCodedDoorHandles,
            string colourCodedMirrors, string maintenancePlanKms, string maintenancePlanYears, string serviceIntervalsKms,
            string servicePlanKms, string servicePlanYears, string warrantyKms, string warrantyYears, string rimSizeFront,
            string tyreSizeFront, string tyreSizeRear, string wheelType)
        {
            ManufacturerName = manufacturerName;
            ModelYear = modelYear;
            CarTypeName = carTypeName;
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
            CarModel = carModel;
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

        public void AddToCache(ICacheRepository repository)
        {
            repository.AddItems<CarSpecification>(SelectAll);
        }

        public int CarId { get; set; }
        public string ManufacturerName { get; set; }
        public int? ModelYear { get; set; }
        public string CarTypeName { get; set; }
        public string TopSpeed { get; set; }
        public string Kilowatts { get; set; }
        public string FuelEconomy { get; set; }
        public string Acceleration { get; set; }
        public string Torque { get; set; }
        public string Emissions { get; set; }
        public string EngineSize { get; set; }
        public string BodyShape { get; set; }
        public string FuelType { get; set; }
        public string TransmissionType { get; set; }
        public string CarFullname { get; set; }
        public string Colour { get; set; }
        public string RainSensorWindscreenWipers { get; set; }
        public string HeadUpDisplay { get; set; }
        public string VehicleType { get; set; }
        public string CarModel { get; set; }
        public string Make { get; set; }
        public string CarType { get; set; }
        public string AirConditioner { get; set; }
        public string ElectricMirrors { get; set; }
        public string FoldAwayMirrors { get; set; }
        public string HeatedSideMirrors { get; set; }
        public string Doors { get; set; }
        public string BoreXStroke { get; set; }
        public string CompressionRatio { get; set; }
        public string Cylinders { get; set; }
        public string ValvesPerCylinder { get; set; }
        public string ABSBrakes { get; set; }
        public string BrakesFrontDiscs { get; set; }
        public string BrakesRearDiscs { get; set; }
        public string FogLampsFront { get; set; }
        public string HeadlightType { get; set; }
        public string HeatedRearWindow { get; set; }
        public string RearWiper { get; set; }
        public string PowerSteering { get; set; }
        public string ColourCodedBumpers { get; set; }
        public string ColourCodedDoorHandles { get; set; }
        public string ColourCodedMirrors { get; set; }
        public string MaintenancePlanKms { get; set; }
        public string MaintenancePlanYears { get; set; }
        public string ServiceIntervalsKms { get; set; }
        public string ServicePlanKms { get; set; }
        public string ServicePlanYears { get; set; }
        public string WarrantyKms { get; set; }
        public string WarrantyYears { get; set; }
        public string RimSizeFront { get; set; }
        public string TyreSizeFront { get; set; }
        public string TyreSizeRear { get; set; }
        public string WheelType { get; set; }
    }
}