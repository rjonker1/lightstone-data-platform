using Lace.Source.Lightstone.Models;

namespace Lace.Source.Lightstone.Repository.Factory
{
    public interface ISetupRepository
    {
        IReadOnlyRepository<Band> BandRepository();
        IReadOnlyRepository<Car> CarRepository();
        IReadOnlyRepository<CarType> CarTypeRepository();
        IReadOnlyRepository<CarVendor> CarVendorRepository();
        IReadOnlyRepository<CarInfo> CarInfoRepository();
        IReadOnlyRepository<CarInfo> Vin12CarInfoRepository();
        IReadOnlyRepository<Make> MakeRepository();
        IReadOnlyRepository<Metric> MetricRepository();
        IReadOnlyRepository<Municipality> MuncipalityRepository();
        IReadOnlyRepository<Sale> SaleRepository();
        IReadOnlyRepository<Statistic> StatisticRepository();
    }
}