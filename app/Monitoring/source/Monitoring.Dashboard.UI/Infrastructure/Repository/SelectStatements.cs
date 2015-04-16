namespace Monitoring.Dashboard.UI.Infrastructure.Repository
{
    public class SelectStatements
    {
        public const string GetDataProviderRequestResponses = "select top 100 * from MonitoringDataProvider where [action] = 'response' order by [date] desc";
    }
}