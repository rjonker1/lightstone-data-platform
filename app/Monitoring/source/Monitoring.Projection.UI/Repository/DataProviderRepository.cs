using System.Collections.Generic;
using System.Linq;
using Monitoring.Projection.UI.Model;

namespace Monitoring.Projection.UI.Repository
{
    public class DataProviderRepository
    {
        public IQueryable<DataProvider> GetMDataProviders()
        {
            //var query = 
            return new List<DataProvider>()
            {
                new DataProvider(1, "Audatex"),
                new DataProvider(2, "Ivid"),
                new DataProvider(3, "IvidTitleHolder"),

            }.AsQueryable();
        }
    }
}