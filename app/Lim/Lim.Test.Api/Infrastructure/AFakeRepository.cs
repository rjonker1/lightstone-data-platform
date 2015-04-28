using System;
using System.Collections.Generic;
using Lim.Test.Api.Models;

namespace Lim.Test.Api.Infrastructure
{
    public class AFakeRepository : IRepository<SomeDealerData>
    {
        public IList<SomeDealerData> GetAll()
        {
            return new List<SomeDealerData>()
            {
                new SomeDealerData() {DealerName = "Toyota Dealer", DealerUser = "Fred"}
            };
        }

        public IList<SomeDealerData> GetWith(object param)
        {
            throw new NotImplementedException();
        }

        public SomeDealerData Get()
        {
            throw new NotImplementedException();
        }

        public SomeDealerData Get(object param)
        {
            throw new NotImplementedException();
        }
    }
}