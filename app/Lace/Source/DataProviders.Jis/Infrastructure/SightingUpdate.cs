using Lace.Domain.DataProviders.Jis.Core.Contracts;
using Lace.Domain.DataProviders.Jis.JisServiceReference;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Jis.Infrastructure
{
    public class SightingUpdate : IUpdateSighting
    {
        public SightingUpdateResult SightingUpdateResult { get; private set; }

        private SightingUpdateRequest _sightingUpdate;
        private readonly IAmJisRequest _request;
        private readonly DataStoreResult _response;

        public SightingUpdate(IAmJisRequest request, DataStoreResult response)
        {
            _request = request;
            _response = response;
        }

        public IUpdateSighting BuildRequest()
        {
            _sightingUpdate = new SightingUpdateRequest()
            {
                SightingId =  _response.VehicleSightingResults.SightingId,
                VehicleSightingId = _response.VehicleSightingResults.Id
            };

            return this;
        }

        public IUpdateSighting Update(JisWsInterfaceSoapClient jisClient, SessionManagementResult session)
        {
            SightingUpdateResult = jisClient.UpdateSighting(session.Id, _sightingUpdate, _request.UserName.Field);
            return this;
        }
    }
}
