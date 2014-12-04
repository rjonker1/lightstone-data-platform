using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.Core.Entities
{
    public class AmortisationFactorModel : IRespondWithAmortisationFactorModel
    {
        public AmortisationFactorModel(int year, double value)
        {
            Year = year;
            Value = value;
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
