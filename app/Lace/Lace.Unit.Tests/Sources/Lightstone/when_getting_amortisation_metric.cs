using System;
using Lace.Models.Lightstone.Dto;
using Lace.Request;
using Lace.Source.Lightstone.Metrics;
using Lace.Source.Lightstone.Metrics.Specifics;
using Lace.Test.Helper.Builders.Requests;
using Lace.Test.Helper.Builders.Sources.Lightstone;
using Xunit.Extensions;

namespace Lace.Unit.Tests.Sources.Lightstone
{
    public class when_getting_amortisation_metric : Specification
    {
        private readonly IRetrieveATypeOfMetric<AmortisedValueModel> _metric;
        private readonly ILaceRequestCarInformation _request;

        public when_getting_amortisation_metric()
        {
            _request = LaceRequestCarInformationRequestBuilder.ForCarId_107483();
            var stats = MetricsBuilder.GetStatistics();
            var bands = MetricsBuilder.GetBands();

            _metric = new AmortisedValueMetric(_request, stats, bands);
        }


        public override void Observe()
        {
            _metric.Get();
        }
    }
}
