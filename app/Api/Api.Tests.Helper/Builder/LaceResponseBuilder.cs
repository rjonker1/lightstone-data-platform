using System.Collections.Generic;
using Api.Tests.Helper.Fakes.Vehicles;
using Lace.Domain.Infrastructure.Core.Dto;

namespace Api.Tests.Helper.Builder
{
    public class LaceResponseBuilder
    {
    }

    public class FakeDataProviderResults
    {
        public IEnumerable<KeyValuePair<string, IList<LaceExternalSourceResponse>>> LaceResponse
        {
            get
            {
                return new Dictionary
                    <string, IList<LaceExternalSourceResponse>>()
                {
                    {
                        "License plate search", new List<LaceExternalSourceResponse>() { new FakeVehicleSearches().ResponseForVviProduct() } 
                    },
                    {
                        "License Scan", new List<LaceExternalSourceResponse>() { new DriversLicenseScanBuilder().ForDriversLicenseResponseFromLace() }
                    },
                    {
                        "Fica", new List<LaceExternalSourceResponse>()
                    }
                };
            }
        }
    }
}
