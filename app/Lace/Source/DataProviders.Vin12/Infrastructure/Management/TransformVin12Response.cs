using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Toolbox.Database.Dtos;

namespace Lace.Domain.DataProviders.Vin12.Infrastructure.Management
{
    public class TransformVin12Response : ITransform
    {
        public IProvideDataFromVin12 Result { get; private set; }
        private readonly List<Vin12CarinformationDto> _carInformation;

        public TransformVin12Response(List<Vin12CarinformationDto> carInformation)
        {
            Continue = carInformation != null && carInformation.Any();
            Result = Continue ? null : Vin12Response.Empty();
            _carInformation = carInformation;
        }

        public void Transform()
        {

            var records = new List<Vin12Record>();
            _carInformation.ForEach(s =>
            {
                Enumerable.Range(s.IntroductionYear, s.YearCounter)
                    .ToList()
                    .ForEach(year => records.Add(new Vin12Record(s.CarId, year, s.CarFullName, s.ImageUrl, s.BodyShape, "")));
            });
            Result = new Vin12Response(records);
            Result.AddResponseState(Result.Vin12Information.Any() ? DataProviderResponseState.VinShort : DataProviderResponseState.NoRecords);
        }

        public bool Continue { get; private set; }
    }
}
