using Lace.Domain.Core.Contracts.Caching;

namespace Lace.Toolbox.Database.Models
{
    public sealed class MmCode : IAmCachable
    {
        public const string SelectWithCarId =
            "select MML_ID, Car_ID, MM_Code from MMLookup MML where MML.Car_ID = @CarId";

        public MmCode()
        {
        }

        public MmCode(int mmlId, int carId, string mmCode)
        {
            MML_ID = mmlId;
            Car_ID = carId;
            MM_Code = mmCode;
        }

        public void AddToCache(ICacheRepository repository)
        {
            throw new System.NotImplementedException();
        }

        public int MML_ID { get; set; }
        public int Car_ID { get; set; }
        public string MM_Code { get; set; }
    }
}