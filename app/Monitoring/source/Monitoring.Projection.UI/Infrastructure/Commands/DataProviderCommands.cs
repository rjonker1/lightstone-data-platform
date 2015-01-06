using Monitoring.Projection.UI.Infrastructure.Dto;

namespace Monitoring.Projection.UI.Infrastructure.Commands
{
    public class GetDataProviderViewRequestCommand
    {
        public readonly DataProviderRequestDto Request;

        public GetDataProviderViewRequestCommand(DataProviderRequestDto request)
        {
            Request = request;
        }
    }
}