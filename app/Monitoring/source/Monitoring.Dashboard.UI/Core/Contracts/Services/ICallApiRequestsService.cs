using Monitoring.Dashboard.UI.Infrastructure.Dto;

namespace Monitoring.Dashboard.UI.Core.Contracts.Services
{
    public interface ICallApiRequestsService
    {
        ApiRequestDto GetApiRequests();
    }
}
