using DataProviders.MMCode.Core.Contracts;
using Lace.Toolbox.Database.Models;

namespace DataProviders.MMCode.Infrastructure.Management
{
    public static class GetMmCode
    {
        static GetMmCode()
        {
        }

        public static void ForCar(IGetMmCode query, int carId, out MmCode mmCode)
        {
            query.GetCarMmCode(carId);
            mmCode = query.MmCode ?? new MmCode();
        }
    }
}