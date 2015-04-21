using System.CodeDom;

namespace Monitoring.Dashboard.UI.Infrastructure.Repository
{
    public class SelectStatements
    {
        public const string GetDataProviderRequestResponses =
            "select top 100 * from MonitoringDataProvider where [action] = 'response' order by [date] desc";

        public const string GetCommitForRequestId =
            "select StreamIdOriginal, Payload, CommitSequence,[CommitStamp] from commits where StreamIdOriginal = @RequestId order by CommitSequence";

        public const string GetCommitForManyRequestId =
            "select StreamIdOriginal, Payload, CommitSequence,[CommitStamp] from commits where StreamIdOriginal in (@RequestIds) order by CommitSequence";

        public const string GetDataProviderStatistics =
            "select (select top 100 Convert(VARCHAR, cast(cast(avg(cast(CAST(ElapsedTime as datetime) as float)) as datetime) as time),20) from [Monitoring].[dbo].[MonitoringDataProvider] where [Action] = 'Response') AvgerageRequestTime,(select count(RequestId) FROM [Monitoring].[dbo].[MonitoringDataProvider] where ([Action] = 'Request')) TotalRequests,(select count(RequestId) FROM [Monitoring].[dbo].[MonitoringDataProvider] where ([Action] = 'Response')) TotalResponses";
    }
}