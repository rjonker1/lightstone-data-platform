using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Test.Helper.Mothers.Requests.Dto
{
    public class CoOrdinateInformation //: IHaveCoOrdinates
    {
        public double Latitude
        {
            get
            {
                return -26.864250004641011;
            }
        }

        public double Longitude
        {
            get { return 32.829399989305713; }
        }

        public string Image
        {
            get { return string.Empty; }
        }
    }
}
