using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Toolbox.Database.Models;

namespace Lace.Domain.DataProviders.Vin12.Infrastructure.Management
{
    public class TransformVin12Response : ITransform
    {
        public IProvideDataFromVin12 Result { get; private set; }
        private readonly List<CarInformation> _carInformation;

        public TransformVin12Response(List<CarInformation> carInformation)
        {
            Continue = carInformation != null && carInformation.Any();
            Result = Continue ? null : Vin12Response.Empty();
            _carInformation = carInformation;
        }

        public void Transform()
        {
            var records = _carInformation.Select(s => new Vin12Record(s.CarId, s.Year, s.CarFullname, s.ImageUrl, s.BodyShape, s.MakeName));
            Result = new Vin12Response(records);
            Result.AddResponseState(Result.Vin12Information.Any() ? DataProviderResponseState.VinShort : DataProviderResponseState.NoRecords);
        }

        public bool Continue { get; private set; }
    }
}
