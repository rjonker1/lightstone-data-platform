using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.DataProviders.Lightstone.Infrastructure.Dto
{
    public class FrequencyModel : IRespondWithFrequencyModel
    {
        public FrequencyModel(string carType, int year, double value)
        {
            CarType = carType;
            Year = year;
            Value = value;
        }

        public string CarType
        {
            get;
            private set;
        }

        public int Year
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
