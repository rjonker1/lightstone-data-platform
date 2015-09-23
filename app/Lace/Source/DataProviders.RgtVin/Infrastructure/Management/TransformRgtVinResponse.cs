using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Extensions;
using Lace.Toolbox.Database.Models;

namespace Lace.Domain.DataProviders.RgtVin.Infrastructure.Management
{
    public sealed class TransformRgtVinResponse : ITransform
    {
        private readonly Vin _vin;

        public IProvideDataFromRgtVin Result { get; private set; }
        public bool Continue { get; private set; }

        public TransformRgtVinResponse(IEnumerable<Vin> response, ICauseCriticalFailure critical)
        {
            Continue = response != null && response.Any();
            Result = Continue ? null : critical.IsCritical() ? RgtVinResponse.Failure(critical.Message) : RgtVinResponse.Empty();
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
