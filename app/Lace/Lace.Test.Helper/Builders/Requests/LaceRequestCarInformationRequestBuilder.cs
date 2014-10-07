using Lace.Domain.Core.Contracts.Requests;
using Lace.Test.Helper.Mothers.Requests.Dto;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LaceRequestCarInformationRequestBuilder
    {
        public static IProvideCarInformationForRequest ForCarId_107483()
        {
            return new RequestCarInformationForCarHavingId107483();
        }

        public static IProvideCarInformationForRequest ForCarId_107483_ButNoVin()
        {
            return new RequestCarInformationForCarHavingId107483ButNoVin();
        }

        public static IProvideCarInformationForRequest ForCarId_110490()
        {
            return new RequestCarInformationForCarHavingId110490();
        }

        public static IProvideCarInformationForRequest ForCarId_113018()
        {
            return new RequestCarInformationForCarHavingId113018();
        }
    }
}
