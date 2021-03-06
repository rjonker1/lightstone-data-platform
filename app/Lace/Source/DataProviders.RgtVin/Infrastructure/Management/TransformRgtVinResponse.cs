﻿using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Toolbox.Database.Models;

namespace Lace.Domain.DataProviders.RgtVin.Infrastructure.Management
{
    public sealed class TransformRgtVinResponse : ITransform
    {
        private readonly Vin _vin;

        public IProvideDataFromRgtVin Result { get; private set; }
        public bool Continue { get; private set; }

        public TransformRgtVinResponse(List<Vin> response)
        {
            Continue = response != null && response.Any();
            Result = Continue ? null : RgtVinResponse.Empty();
            _vin = Continue ? response.FirstOrDefault() : new Vin();
        }

        public void Transform()
        {
            Result = new RgtVinResponse(_vin.Colour, _vin.Month, 0, 0, _vin.Car_ID.HasValue ? _vin.Car_ID.Value : 0,
                _vin.MakeName, _vin.CarModel, "", _vin.VIN, _vin.Year_ID.HasValue ? _vin.Year_ID.Value : 0);
            Result.SetCarName();
            Result.AddResponseState(DataProviderResponseState.Successful);
        }
    }
}
