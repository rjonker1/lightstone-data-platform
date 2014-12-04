using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.Core.Entities
{
    public class PriceModel : IRespondWithPriceModel
    {

        public PriceModel(string name, decimal value)
        {
            Name = name;
            Value = value;
        }

        public string Name
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
