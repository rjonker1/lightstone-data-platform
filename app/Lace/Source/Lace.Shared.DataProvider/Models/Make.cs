using Lace.Shared.DataProvider.Contracts;

namespace Lace.Shared.DataProvider.Models
{
    public class Make : IAmCachable
    {
        public const string SelectAll = @"SELECT * FROM Make";
        public const string CacheAllKey = "urn:Auto_Carstats:Make";

        public Make()
        {
             
        }

        public Make(int makeId, string makeName)
        {
            Make_ID = makeId;
            MakeName = makeName;
        }

        public void AddToCache(ICacheRepository repository)
        {
            repository.AddItems<Make>(SelectAll, CacheAllKey);
        }

        public int Make_ID { get; set; }
        public string MakeName { get; set; }

      
    }
}
