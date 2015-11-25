using Api.Infrastructure.Dto;

namespace Api.Infrastructure.Base.Services
{
    public interface ICallApiRequestsService
    {
        ApiRequestDto GetApiRequests();
    }
}
