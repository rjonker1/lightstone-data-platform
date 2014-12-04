using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Jis.Core.Contracts;
using Lace.Domain.DataProviders.Jis.JisServiceReference;

namespace Lace.Domain.DataProviders.Jis.Infrastructure
{
    public class SightingUpdate : IUpdateSighting
    {
        public SightingUpdateResult SightingUpdateResult { get; private set; }

        private SightingUpdateRequest _sightingUpdate;
        private readonly ILaceRequest _request;
        private readonly DataStoreResult _response;

        public SightingUpdate(ILaceRequest request,  DataStoreResult response)
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
            SightingUpdateResult = jisClient.UpdateSighting(session.Id, _sightingUpdate, _request.User.UserName);
            return this;
        }
    }
}
