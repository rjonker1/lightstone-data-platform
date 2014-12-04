using Lace.Domain.Core.Contracts.DataProviders.Specifics;

namespace Lace.Domain.Core.Entities
{
    public class AuctionFactorModel : IRespondWithAuctionFactorModel
    {
        public AuctionFactorModel(string make, decimal value)
        {
            Make = make;
            Value = value;
        }

        public string Make
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
