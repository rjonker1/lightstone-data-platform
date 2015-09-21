using DataProviders.Lightstone.MMCode.Core.Contracts;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Models;

namespace DataProviders.Lightstone.MMCode.Infrastructure.Management
{
    public static class GetMmCode
    {
        static GetMmCode()
        {
        }

        public static void ForCar(IGetMmCode worker, int carId, out MmCode mmCode)
        {
            worker.GetCarMmCode(carId);
            mmCode = worker.MmCode ?? new MmCode();
        }
    }
}