using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using Lace.Domain.Infrastructure.Core.Dto;

namespace Api.Tests.Helper.Fakes.Vehicles
{
    public class FakeVehicleSearches
    {
        public LaceExternalSourceResponse ResponseForVviProduct()
        {
            return new LaceExternalSourceResponse()
            {
                Response = new LaceResponse()
                {
                    IvidResponse = new IvidResponse(),
                    IvidResponseHandled = new IvidResponseHandled(),

                    LightstoneResponse = new LightstoneResponse(),
                    LightstoneResponseHandled = new LightstoneResponseHandled(),

                    IvidTitleHolderResponse = new IvidTitleHolderResponse(),
                    IvidTitleHolderResponseHandled = new IvidTitleHolderResponseHandled(),

                    RgtResponse = new RgtResponse(),
                    RgtResponseHandled = new RgtResponseHandled(),

                    RgtVinResponse = new RgtVinResponse(),
                    RgtVinResponseHandled = new RgtVinResponseHandled(),

                    AudatexResponse = new AudatexResponse(new IProvideAccidentClaim[] {}),
                    AudatexResponseHandled = new AudatexResponseHandled()
                }
            };
        }
    }
}
