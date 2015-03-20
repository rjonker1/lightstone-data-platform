using System.Collections.Generic;
using System.Collections.ObjectModel;
using Api.Tests.Helper.Fakes.Vehicles;
using Lace.Domain.Core.Contracts.Requests;

namespace Api.Tests.Helper.Builder
{
    public class LaceResponseBuilder
    {
    }

    public class FakeDataProviderResults
    {
        public IEnumerable<KeyValuePair<string, ICollection<IPointToLaceProvider>>> LaceResponse
        {
            get
            {
                return new Dictionary
                    <string, ICollection<IPointToLaceProvider>>()
                {
                    {
                        "License plate search", new FakeVehicleSearches().ResponseForVviProduct()
                    },
                    {
                        "License Scan", new DriversLicenseScanBuilder().ForDriversLicenseResponseFromLace()
                    },
                    {
                        "Lightstone Properties Search", new LightstonePropertyBuilder().ForLightstonePropertyResponse()
                    },
                    {
                        "Lightstone Business Search", new LightstoneBusinessBuilder().ForLightstoneBusinessResponse()
                    },
                    {
                        "Fica", new Collection<IPointToLaceProvider>()
                    }
                };
            }
        }
    }
}
