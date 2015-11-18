using System.Collections.Generic;
using Monitoring.Dashboard.UI.Infrastructure.Dto;

namespace Monitoring.Dashboard.UI.Core.Contracts.Services
{
    public interface ICallApiRequestsService
    {
        List<ApiRequestDto> GetApiRequests();
    }
}
