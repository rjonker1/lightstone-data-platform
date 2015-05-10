using System.Linq;
using Lace.Shared.DataProvider.Models;
using Lace.Shared.DataProvider.Repositories;

namespace Lace.Test.Helper.Fakes.Lace.Lighstone
{
    public class FakeVin12CarInfoRepository : IReadOnlyRepository
    {
        private readonly string _vin;

        public FakeVin12CarInfoRepository(string vin)
        {
            _vin = vin;
        }

        public IQueryable<TItem> GetAll<TItem>(string sql) where TItem : class
        {
            return (IQueryable<TItem>)Mothers.Sources.Lightstone.CarInfoData.CarInformationFromVinShort().Select(
                    s =>
                        new CarInformation(s.Value.CarId, s.Value.Year, s.Value.CarTypeId, s.Value.ManufacturerId,
                            s.Value.CarFullname, s.Value.CarModel, s.Value.BodyShape, s.Value.FuelType,
                            s.Value.Market, s.Value.TransmissionType, s.Value.ModelYear, s.Value.IntroductionDate,
                            s.Value.ImageUrl, s.Value.Quarter, s.Value.MakeId)).AsQueryable();
        }

        public IQueryable<TItem> Get<TItem>(string sql, object param) where TItem : class
        {
            return (IQueryable<TItem>)Mothers.Sources.Lightstone.CarInfoData.CarInformationFromVinShort()
                    .Where(w => w.Key == _vin)
                    .Select(
                        s =>
                            new CarInformation(s.Value.CarId, s.Value.Year, s.Value.CarTypeId, s.Value.ManufacturerId,
                                s.Value.CarFullname, s.Value.CarModel, s.Value.BodyShape, s.Value.FuelType,
                                s.Value.Market, s.Value.TransmissionType, s.Value.ModelYear, s.Value.IntroductionDate,
                                s.Value.ImageUrl, s.Value.Quarter, s.Value.MakeId)).AsQueryable();
        }


        public IQueryable<TItem> GetAll<TItem>(string sql, System.Func<TItem, bool> predicate) where TItem : class
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<TItem> Get<TItem>(string sql, object param, System.Func<TItem, bool> predicate) where TItem : class
        {
            throw new System.NotImplementedException();
        }
    }
}
