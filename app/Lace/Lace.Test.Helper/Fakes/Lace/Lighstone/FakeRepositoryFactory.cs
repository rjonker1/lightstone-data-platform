using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Test.Helper.Builders.Sources.Lightstone;
using Lace.Toolbox.Database.Dtos;
using Lace.Toolbox.Database.Models;
using Lace.Toolbox.Database.Repositories;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeDataProviderRepository : IReadOnlyRepository
    {
        public IEnumerable<TItem> GetAll<TItem>(Func<TItem, bool> predicate) where TItem : class
        {
            if (typeof (TItem) == (typeof (CarInformationDto)))
                return new FakeCarInfoRepository().GetAll(predicate);

            var data = _data.FirstOrDefault(w => w.Key == typeof(TItem)).Value;
            return (IEnumerable<TItem>)data;
        }

        public IEnumerable<TItem> Get<TItem>(string sql, object param) where TItem : class
        {
            var data = _data.FirstOrDefault(w => w.Key == typeof(TItem)).Value;
            return (IEnumerable<TItem>)data;
        }

        private readonly Dictionary<Type, IEnumerable<object>> _data = new Dictionary<Type, IEnumerable<object>>()
        {
            {typeof(Band), BandsDataBuilder.ForAllBands()},
            {typeof(Make), MakeDataBuilder.ForAllMakes()},
            {typeof(Metric), MetricDataBuilder.ForAllMetrics()},
            {typeof(Municipality), MuncipalityDataBuilder.ForAllMunicipalities()},
            {typeof(Sale), SaleDataBuilder.ForCarSalesOnCarId_107483()},
            {typeof(StatisticDto), StatisticsDataBuilder.ForCarId_107483()},
            {typeof(CarInformationDto),Mothers.Sources.Lightstone.CarInfoData.CarInformation() }
        };
    }
}
