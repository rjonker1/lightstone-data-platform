using System.Linq;
using Lace.Shared.DataProvider.Repositories;
using Lace.Test.Helper.Builders.Sources.Lightstone;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeSaleRepository : IReadOnlyRepository
    {
        public IQueryable<TItem> GetAll<TItem>(string sql) where TItem : class
        {
            return (IQueryable<TItem>)SaleDataBuilder.ForCarSalesOnCarId_107483().AsQueryable();
        }

        public IQueryable<TItem> Get<TItem>(string sql, object param) where TItem : class
        {
            return (IQueryable<TItem>)SaleDataBuilder.ForCarSalesOnCarId_107483().AsQueryable();
        }
    
        //public IEnumerable<Sale> Get(string sql, object param, string cacheKey)
        //{
        //    return SaleDataBuilder.ForCarSalesOnCarId_107483();
        //}

        //public IEnumerable<Sale> GetAll(string sql, string cacheKey)
        //{
        //    return SaleDataBuilder.ForCarSalesOnCarId_107483();
        //}
    }
}
