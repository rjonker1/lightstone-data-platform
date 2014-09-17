using Lace.Models.Responses.Sources.Specifics;

namespace Lace.Models.Lightstone.Dto
{
    public class AmortisedValueModel : IRespondWithAmortisedValueModel
    {
        public AmortisedValueModel(string year, decimal value)
        {
            Year = year;
            Value = value;
        }

        public string Year
        {
            get;
            private set;
        }

        public decimal Value
        {
            get;
            private set;
        }
    }
}
