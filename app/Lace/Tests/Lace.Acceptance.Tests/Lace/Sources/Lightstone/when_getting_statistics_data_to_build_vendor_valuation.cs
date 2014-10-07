using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Test.Helper.Mothers.Sources.Lightstone;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Sources.Lightstone
{
    public class when_getting_statistics_data_to_build_vendor_valuation : Specification
    {
        private readonly IGetStatistics _getStatistics;
        private IReadOnlyRepository<StatisticsData> _repository;

        public override void Observe()
        {
        }



    }
}
