using Monitoring.Dashboard.UI.Infrastructure.Dto;

namespace Monitoring.Dashboard.UI.Infrastructure.Commands
{
    public class GetDataProviderViewCommand
    {
        public readonly DataProviderViewDto Request;

        public GetDataProviderViewCommand(DataProviderViewDto request)
        {
            Request = request;
        }
    }
}