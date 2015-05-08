using System.Linq;
using System.Reflection;
using Lace.Shared.DataProvider.Models;
using Lace.Shared.DataProvider.Repositories;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeCarInfoRepository : IReadOnlyRepository
    {

        public IQueryable<TItem> GetAll<TItem>(string sql) where TItem : class
        {
            return (IQueryable<TItem>)Mothers.Sources.Lightstone.CarInfoData.CarInformation().AsQueryable();
        }

        public IQueryable<TItem> Get<TItem>(string sql, object param) where TItem : class
        {
            PropertyInfo[] props = param.GetType().GetProperties();
            var vin = props[0].GetValue(param);

            var data =
                Mothers.Sources.Lightstone.CarInfoData.CarInformationWithVin().
                    Where(w => w.Key == vin.ToString())
                    .Select(
                        s =>
                            new CarInformation(s.Value.CarId, s.Value.Year, s.Value.CarTypeId, s.Value.ManufacturerId,
                                s.Value.CarFullname, s.Value.CarModel, s.Value.BodyShape, s.Value.FuelType,
                                s.Value.Market, s.Value.TransmissionType, s.Value.ModelYear, s.Value.IntroductionDate,
                                s.Value.ImageUrl, s.Value.Quarter, s.Value.MakeId)).ToList();

            return (IQueryable<TItem>)data.AsQueryable();
        }
    }
}
