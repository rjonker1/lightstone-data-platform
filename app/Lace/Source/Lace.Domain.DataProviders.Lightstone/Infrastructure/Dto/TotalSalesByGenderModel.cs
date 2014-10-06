using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.DataProviders.Lightstone.Infrastructure.Dto
{
    public class TotalSalesByGenderModel : IRespondWithTotalSalesByGenderModel
    {
        public TotalSalesByGenderModel(string carType, string band, double value)
        {
            CarType = carType;
            Band = band;
            Value = value;
        }

        public string CarType
        {
            get;
            private set;
        }

        public string Band
        {
            get;
            private set;
        }

        public double Value
        {
            get;
            private set;
        }
    }
}
