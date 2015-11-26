using Api.Infrastructure.Base.Handlers;
using Api.Infrastructure.Base.Services;
using Api.Infrastructure.Dto;
using Common.Logging;

namespace Api.Infrastructure.Services
{
    public class ApiRequestService : ICallApiRequestsService
    {
        private static readonly ILog Log = LogManager.GetLogger<ApiRequestService>();
        private readonly IHandleApiRequests _apiRequestsHandler;

        public ApiRequestService(IHandleApiRequests apiRequestsHandler)
        {
            _apiRequestsHandler = apiRequestsHandler;
        }

        public ApiRequestDto GetApiRequests()
        {
            Log.InfoFormat("Getting Api Requests for Monitoring");
            _apiRequestsHandler.Handle();
            return _apiRequestsHandler.ApiRequests;
        }
    }
}