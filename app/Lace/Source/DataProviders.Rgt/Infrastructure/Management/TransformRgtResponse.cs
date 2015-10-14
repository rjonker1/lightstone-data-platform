using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Toolbox.Database.Models;

namespace Lace.Domain.DataProviders.Rgt.Infrastructure.Management
{
    public sealed class TransformRgtResponse : ITransform
    {
        public bool Continue { get; private set; }
        public IProvideDataFromRgt Result { get; private set; }

        private readonly CarSpecification _carSpecification;

        public TransformRgtResponse(List<CarSpecification> carSpecifications)
        {
            Continue = carSpecifications != null && carSpecifications.Any();
            _carSpecification = Continue ? carSpecifications.FirstOrDefault() : new CarSpecification();
            Result = Continue ? null : RgtResponse.Empty();
        }

        public void Transform()
        {
            Result = new RgtResponse(_carSpecification.ManufacturerName, _carSpecification.ModelYear.HasValue ? _carSpecification.ModelYear.Value : 0,_carSpecification.CarTypeName,
                _carSpecification.TopSpeed, _carSpecification.Kilowatts,_carSpecification.FuelEconomy,_carSpecification.Acceleration,_carSpecification.Torque,_carSpecification.Emissions,_carSpecification.EngineSize,
                _carSpecification.BodyShape,_carSpecification.FuelType,_carSpecification.TransmissionType,_carSpecification.CarFullname,_carSpecification.Colour,_carSpecification.RainSensorWindscreenWipers,_carSpecification.HeadUpDisplay,
                _carSpecification.VehicleType,_carSpecification.CarModel,string.Empty,_carSpecification.CarType, _carSpecification.AirConditioner, _carSpecification.ElectricMirrors, 
                _carSpecification.FoldAwayMirrors, _carSpecification.HeatedSideMirrors, _carSpecification.Doors, _carSpecification.BoreXStroke, _carSpecification.CompressionRatio, 
                _carSpecification.Cylinders, _carSpecification.ValvesPerCylinder, _carSpecification.ABSBrakes, _carSpecification.BrakesFrontDiscs, _carSpecification.BrakesRearDiscs, 
                _carSpecification.FogLampsFront, _carSpecification.HeadlightType, _carSpecification.HeatedRearWindow, _carSpecification.RearWiper, _carSpecification.PowerSteering, 
                _carSpecification.ColourCodedBumpers, _carSpecification.ColourCodedDoorHandles, _carSpecification.ColourCodedMirrors, _carSpecification.MaintenancePlanKms, 
                _carSpecification.MaintenancePlanYears, _carSpecification.ServiceIntervalsKms, _carSpecification.ServicePlanKms, _carSpecification.ServicePlanYears, 
                _carSpecification.WarrantyKms, _carSpecification.WarrantyYears, _carSpecification.RimSizeFront, _carSpecification.TyreSizeFront, _carSpecification.TyreSizeRear,
                _carSpecification.WheelType);
            Result.AddResponseState(DataProviderResponseState.Successful);
        }
    }
}
