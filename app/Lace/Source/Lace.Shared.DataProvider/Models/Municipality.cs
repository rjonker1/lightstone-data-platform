using Lace.Shared.DataProvider.Contracts;

namespace Lace.Shared.DataProvider.Models
{
    public class Municipality : IAmCachable
    {
        public const string SelectAll = @"SELECT * FROM Municipality";
        public const string CacheAllKey = "urn:Auto_Carstats:Municipality";
        public Municipality()
        {

        }

        public Municipality(int muncipalityId, string muncipalityName)
        {
            Municipality_ID = muncipalityId;
            MunicipalityName = muncipalityName;
        }

        public void AddToCache(ICacheRepository repository)
        {
            repository.AddItems<Municipality>(SelectAll, CacheAllKey);
        }

        public int Municipality_ID { get; set; }
        public string MunicipalityName { get; set; }

       
    }
}
