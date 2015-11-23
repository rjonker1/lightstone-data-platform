using Monitoring.Dashboard.UI.Infrastructure.Dto;
namespace Monitoring.Dashboard.UI.Core.Contracts.Handlers
{
    public interface IHandleApiRequests
    {
        ApiRequestDto ApiRequests { get; }
        void Handle();
    }
}
