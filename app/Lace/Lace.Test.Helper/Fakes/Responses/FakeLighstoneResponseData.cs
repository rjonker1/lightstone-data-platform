﻿using Lace.Models.Lightstone.Dto;
using Lace.Request;
using Lace.Source.Lightstone.Cars;
using Lace.Source.Lightstone.Metrics;
using Lace.Test.Helper.Fakes.Lace.Lighstone;

namespace Lace.Test.Helper.Fakes.Responses
{
    public class FakeLighstoneRetrievalData
    {
        public static IRetrieveValuationFromMetrics GetValuationFromMetrics(ILaceRequestCarInformation request)
        {
            return new FakeBaseRetrievalMetric(request, new Valuation()).SetupDataSources()
                .GenerateData()
                .BuildValuation();
        }

        public static IRetrieveCarInformation GetCarInformation(ILaceRequestCarInformation request)
        {
            return new FakeRetrieveCarInformationDetail(request).SetupDataSources()
                .GenerateData()
                .BuildCarInformation();
        }
    }
}
