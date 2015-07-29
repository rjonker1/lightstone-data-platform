using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Shared.DataProvider.Models;
using Lace.Shared.DataProvider.Repositories;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeCarInfoRepository : IReadOnlyRepository
    {

        public IEnumerable<TItem> GetAll<TItem>(System.Func<TItem, bool> predicate) where TItem : class
        {
            //PropertyInfo[] props = param.GetType().GetProperties();
            //var vin = props[0].GetValue(param);
            if (predicate == null)
                return Enumerable.Empty<TItem>();

            if (typeof(TItem) == (typeof(Sale)))
                return (IEnumerable<TItem>)Builders.Sources.Lightstone.SaleDataBuilder.ForCarSalesOnCarId_107483();

            var data =
                Mothers.Sources.Lightstone.CarInfoData.CarInformationWithVin()
                    .Select(
                        s =>
                            new CarInformation(s.Key, s.Value.CarId, s.Value.Year, s.Value.CarTypeId, s.Value.ManufacturerId,
                                s.Value.CarFullname, s.Value.CarModel, s.Value.BodyShape, s.Value.FuelType,
                                s.Value.Market, s.Value.TransmissionType, s.Value.ModelYear, s.Value.IntroductionDate,
                                s.Value.ImageUrl, s.Value.Quarter, s.Value.MakeId)).ToList();

            

            return (IEnumerable<TItem>) data.Where((Func<CarInformation, bool>) predicate);
        }

        public IEnumerable<TItem> Get<TItem>(string sql, object param) where TItem : class
        {
            if(typeof(TItem) == (typeof(CarInformation)))
                return (IEnumerable<TItem>)Mothers.Sources.Lightstone.CarInfoData.CarInformation();

            if(typeof(TItem) == (typeof(Statistic)))
                return (IEnumerable<TItem>)Builders.Sources.Lightstone.StatisticsDataBuilder.ForCarId_107483();

            if (typeof(TItem) == (typeof(Metric)))
                return (IEnumerable<TItem>)Builders.Sources.Lightstone.MetricDataBuilder.ForAllMetrics();

            if (typeof(TItem) == (typeof(Sale)))
                return (IEnumerable<TItem>)Builders.Sources.Lightstone.SaleDataBuilder.ForCarSalesOnCarId_107483();

            if (typeof(TItem) == (typeof(Make)))
                return (IEnumerable<TItem>)Builders.Sources.Lightstone.MakeDataBuilder.ForAllMakes();

            if (typeof(TItem) == (typeof(Municipality)))
                return (IEnumerable<TItem>)Builders.Sources.Lightstone.MuncipalityDataBuilder.ForAllMunicipalities();

            if (typeof(TItem) == (typeof(Band)))
                return (IEnumerable<TItem>)Builders.Sources.Lightstone.BandsDataBuilder.ForAllBands();

            return Enumerable.Empty<TItem>();
        }
    }
}
