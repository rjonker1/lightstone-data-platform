using Lace.Models.Responses.Sources.Specifics;

namespace Lace.Models.Lightstone.Dto
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
