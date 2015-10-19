using System.Linq;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Queries;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Lace.Lighstone;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Repositories;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.Lightstone
{
    public class when_getting_statistics : Specification
    {
        private readonly IReadOnlyRepository _repository;
        private readonly IGetStatistics _getStatistics;
        private readonly IHaveCarInformation _request;       

        public when_getting_statistics()
        {
            _repository = new FakeStatisticsRepository();
            _getStatistics = new StatisticsQuery(_repository);
            _request = LaceRequestCarInformationRequestBuilder.ForCarId_107483();
        }


        public override void Observe()
        {
           _getStatistics.GetStatistics(_request);
        }

        [Observation]
        public void lightstone_statistics_for_car_id_must_exist()
        {
            _getStatistics.Statistics.ShouldNotBeNull();
            _getStatistics.Statistics.Count().ShouldNotEqual(0);
        }
    }
}
