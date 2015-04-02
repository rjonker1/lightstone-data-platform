using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Mothers.Requests.Dto;

namespace Lace.Test.Helper.Builders.Requests
{
    public class LaceRequestCarInformationRequestBuilder
    {
        public static IHaveCarInformation ForCarId_107483()
        {
            return new RequestCarInformationForCarHavingId107483();
        }

        public static IHaveCarInformation ForCarId_107483_ButNoVin()
        {
            return new RequestCarInformationForCarHavingId107483ButNoVin();
        }

        public static IHaveCarInformation ForCarId_110490()
        {
            return new RequestCarInformationForCarHavingId110490();
        }

        public static IHaveCarInformation ForCarId_113018()
        {
            return new RequestCarInformationForCarHavingId113018();
        }
    }
}
