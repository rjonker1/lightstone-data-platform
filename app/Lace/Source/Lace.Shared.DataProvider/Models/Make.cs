using Lace.Domain.Core.Contracts.Caching;

namespace Lace.Toolbox.Database.Models
{
    public class Make : IAmCachable
    {
        public const string SelectAll = @"SELECT * FROM Make";

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
            repository.AddItems<Make>(SelectAll);
        }

        public int Make_ID { get; set; }
        public string MakeName { get; set; }

      
    }
}
