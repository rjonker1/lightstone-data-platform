using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.Core.Entities
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
