using Lace.Request;
using Lace.Test.Helper.Mothers.Requests.Dto;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LaceRequestCarInformationRequestBuilder
    {
        public static ILaceRequestCarInformation ForCarId_107483()
        {
            return new RequestCarInformationForCarHavingId107483();
        }

        public static ILaceRequestCarInformation ForCarId_107483_ButNoVin()
        {
            return new RequestCarInformationForCarHavingId107483ButNoVin();
        }

        public static ILaceRequestCarInformation ForCarId_110490()
        {
            return new RequestCarInformationForCarHavingId110490();
        }

        public static ILaceRequestCarInformation ForCarId_113018()
        {
            return new RequestCarInformationForCarHavingId113018();
        }
    }
}
