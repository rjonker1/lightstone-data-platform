using System.Linq;
using Lace.Request;
using Lace.Source.Lightstone.DataObjects;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Fakes.Lace.Lighstone;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.Lightstone
{
    public class when_getting_statistics : Specification
    {
        private readonly IReadOnlyRepository<Statistic> _repository;
        private readonly IGetStatistics _getStatistics;
        private readonly ILaceRequestCarInformation _request;       

        public when_getting_statistics()
        {
            _repository = new FakeStatisticsRepository();
            _getStatistics = new StatisticsData(_repository);
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
