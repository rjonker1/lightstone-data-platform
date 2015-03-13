using System.Collections.ObjectModel;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;

namespace Api.Tests.Helper.Fakes.Vehicles
{
    public class FakeVehicleSearches
    {
        public Collection<IPointToLaceProvider> ResponseForVviProduct()
        {
            return new Collection<IPointToLaceProvider>()
            {
                new IvidResponse(),
                new LightstoneAutoResponse(),
                new IvidTitleHolderResponse(),
                new RgtResponse(),
                new RgtVinResponse(),
                new AudatexResponse(new IProvideAccidentClaim[] {})
            };
        }
    }
}
