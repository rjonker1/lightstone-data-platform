namespace Shared.BuildingBlocks.Api.ApiClients
{
    public interface IReportApiClient : IApiClient { }

    public class ReportApiClient : ApiClientBase, IReportApiClient
    {
        public ReportApiClient() : base(AppSettings.ReportApi.BaseUrl)
        {
        }
    }
}