using Api.Infrastructure.Dto;
namespace Api.Infrastructure.Base.Handlers
{
    public interface IHandleApiRequests
    {
        ApiRequestDto ApiRequests { get; }
        void Handle();
    }
}
