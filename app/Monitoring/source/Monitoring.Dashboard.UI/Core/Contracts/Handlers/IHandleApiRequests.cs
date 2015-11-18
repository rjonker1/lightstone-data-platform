using System.Collections.Generic;
using Monitoring.Dashboard.UI.Infrastructure.Dto;

namespace Monitoring.Dashboard.UI.Core.Contracts.Handlers
{
    public interface IHandleApiRequests
    {
        List<ApiRequestDto> ApiRequests { get; }
        void Handle();
    }
}
