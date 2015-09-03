using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Toolbox.Database.Repositories;

namespace Lace.Domain.DataProviders.Lightstone.Infrastructure.Management
{
    public static class GetMetricType
    {
        static GetMetricType()
        {
        }

        public static void OfBaseRetrievalMetric(IHaveCarInformation request, IReadOnlyRepository repository, out IRetrieveValuationFromMetrics metrics)
        {
            metrics =
               new BaseRetrievalMetric(request, new Valuation(),
                   repository)
                   .SetupDataSources()
                   .GenerateData()
                   .BuildValuation();
        }
    }
}