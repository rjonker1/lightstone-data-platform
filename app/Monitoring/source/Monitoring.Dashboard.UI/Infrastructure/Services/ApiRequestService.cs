using Common.Logging;
using Monitoring.Dashboard.UI.Core.Contracts.Handlers;
using Monitoring.Dashboard.UI.Core.Contracts.Services;
using Monitoring.Dashboard.UI.Infrastructure.Dto;

namespace Monitoring.Dashboard.UI.Infrastructure.Services
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