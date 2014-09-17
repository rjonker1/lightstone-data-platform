using Lace.Models.Responses.Sources.Specifics;

namespace Lace.Models.Lightstone.Dto
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
