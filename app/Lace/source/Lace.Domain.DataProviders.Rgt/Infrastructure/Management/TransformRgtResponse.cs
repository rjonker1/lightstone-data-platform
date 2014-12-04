using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Rgt.Core.Models;

namespace Lace.Domain.DataProviders.Rgt.Infrastructure.Management
{
    public class TransformRgtResponse : ITransformResponseFromDataProvider
    {
        public bool Continue { get; private set; }
        public IProvideDataFromRgt Result { get; private set; }

        private readonly CarSpecification _carSpecification;

        public TransformRgtResponse(IEnumerable<CarSpecification> carSpecifications)
        {
            Continue = carSpecifications != null && carSpecifications.Any();
            _carSpecification = Continue ? carSpecifications.FirstOrDefault() : new CarSpecification();
            Result = Continue ? new RgtResponse() : null;
        }

        public void Transform()
        {
            Result = new RgtResponse(_carSpecification.ManufacturerName, _carSpecification.ModelYear.HasValue ? _carSpecification.ModelYear.Value : 0,_carSpecification.CarTypeName,
                _carSpecification.TopSpeed, _carSpecification.Kilowatts,_carSpecification.FuelEconomy,_carSpecification.Acceleration,_carSpecification.Torque,_carSpecification.Emissions,_carSpecification.EngineSize,
                _carSpecification.BodyShape,_carSpecification.FuelType,_carSpecification.TransmissionType,_carSpecification.CarFullname,_carSpecification.Colour,_carSpecification.RainSensorWindscreenWipers,_carSpecification.HeadUpDisplay,
                _carSpecification.VehicleType,_carSpecification.CarModel,string.Empty,_carSpecification.CarType);
        }
    }
}
