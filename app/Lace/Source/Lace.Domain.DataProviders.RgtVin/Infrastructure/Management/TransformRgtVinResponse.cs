using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Dto;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.RgtVin.Core.Models;

namespace Lace.Domain.DataProviders.RgtVin.Infrastructure.Management
{
    public class TransformRgtVinResponse : ITransformResponseFromDataProvider
    {
        private readonly Vin _vin;

        public RgtVinResponse Result { get; private set; }
        public bool Continue { get; private set; }

        public TransformRgtVinResponse(IEnumerable<Vin> response)
        {
            Continue = response != null && response.Any();
            Result = Continue ? new RgtVinResponse() : null;

            _vin = Continue ? response.FirstOrDefault() : new Vin();
        }

        public void Transform()
        {
            Result = new RgtVinResponse(_vin.Colour, _vin.Month, 0, 0, _vin.Car_ID.HasValue ? _vin.Car_ID.Value : 0,
                _vin.MakeName, _vin.CarModel, "", _vin.VIN, _vin.Year_ID.HasValue ? _vin.Year_ID.Value : 0);
            Result.SetCarName();
        }
    }
}
