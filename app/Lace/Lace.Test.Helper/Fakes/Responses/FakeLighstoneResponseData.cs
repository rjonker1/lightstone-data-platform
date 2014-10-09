﻿using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.CrossCutting.DataProvider.Car.Infrastructure;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.Dto;
using Lace.Domain.DataProviders.Lightstone.Services;
using Lace.Test.Helper.Fakes.Lace.Lighstone;

namespace Lace.Test.Helper.Fakes.Responses
{
    public class FakeLighstoneRetrievalData
    {
        public static IRetrieveValuationFromMetrics GetValuationFromMetrics(IProvideCarInformationForRequest request)
        {
            return new FakeBaseRetrievalMetric(request, new Valuation())
                .SetupDataSources()
                .GenerateData()
                .BuildValuation();
        }

        public static IRetrieveCarInformation GetCarInformation(ILaceRequest request)
        {
            return new RetrieveCarInformationDetail(request, new FakeCarRepositioryFactory())
                .SetupDataSources()
                .GenerateData()
                .BuildCarInformation()
                .BuildCarInformationRequest();
        }
    }
}
