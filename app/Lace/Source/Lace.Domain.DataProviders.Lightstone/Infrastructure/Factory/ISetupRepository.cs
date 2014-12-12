using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Domain.DataProviders.Lightstone.Infrastructure.Factory
{
    public interface ISetupRepository
    {
        IReadOnlyRepository<Band> BandRepository();
        IReadOnlyRepository<Car> CarRepository();
        IReadOnlyRepository<CarType> CarTypeRepository();
        IReadOnlyRepository<CarVendor> CarVendorRepository();
        IReadOnlyRepository<Make> MakeRepository();
        IReadOnlyRepository<Metric> MetricRepository();
        IReadOnlyRepository<Municipality> MuncipalityRepository();
        IReadOnlyRepository<Sale> SaleRepository();
        IReadOnlyRepository<Statistic> StatisticRepository();
        void Dispose();
    }
}