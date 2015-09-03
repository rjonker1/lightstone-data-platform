using Lace.Domain.Core.Contracts.Caching;

namespace Lace.Toolbox.Database.Models
{
    public class Municipality : IAmCachable
    {
        public const string SelectAll = @"SELECT * FROM Municipality";
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
            repository.AddItems<Municipality>(SelectAll);
        }

        public int Municipality_ID { get; set; }
        public string MunicipalityName { get; set; }

       
    }
}
