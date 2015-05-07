using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Shared.DataProvider.Models;
using Lace.Shared.DataProvider.Repositories;
using Lace.Test.Helper.Builders.Sources.Lightstone;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeDataProviderRepository : IReadOnlyRepository
    {
        public IQueryable<TItem> GetAll<TItem>(string sql, string cacheKey) where TItem : class
        {
            var data = _data.FirstOrDefault(w => w.Key == typeof(TItem)).Value;
            return (IQueryable<TItem>) data;
        }

        public IQueryable<TItem> Get<TItem>(string sql, object param, string cacheKey) where TItem : class
        {
            var data = _data.FirstOrDefault(w => w.Key == typeof(TItem)).Value;
            return (IQueryable<TItem>)data;
        }

        private readonly Dictionary<Type, IQueryable<object>> _data = new Dictionary<Type, IQueryable<object>>()
        {
            {typeof(Band), BandsDataBuilder.ForAllBands().AsQueryable()},
            {typeof(Make), MakeDataBuilder.ForAllMakes().AsQueryable()},
            {typeof(Metric), MetricDataBuilder.ForAllMetrics().AsQueryable()},
            {typeof(Municipality), MuncipalityDataBuilder.ForAllMunicipalities().AsQueryable()},
            {typeof(Sale), SaleDataBuilder.ForCarSalesOnCarId_107483().AsQueryable()},
            {typeof(Statistic), StatisticsDataBuilder.ForCarId_107483().AsQueryable()},
        };
    }
}
