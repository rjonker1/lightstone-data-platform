namespace Monitoring.Dashboard.UI.Infrastructure.Repository
{
    public class SelectStatements
    {
        public const string GetDataProviderRequestResponses =
            "select top 100 * from MonitoringDataProvider where [action] = 'response' order by [date] desc";

        public const string GetCommitForRequestId =
            "select Id, Payload, CommitNumber, CommitSequence,[CommitStamp] from [DataProvider].[dbo].[CommandLog] where Id = @RequestId order by CommitNumber, CommitSequence";

        //public const string GetCommitForManyRequestId =
        //    "select StreamIdOriginal, Payload, CommitSequence,[CommitStamp] from commits where StreamIdOriginal in @RequestIds order by CommitSequence";
        public const string GetCommitForManyRequestId =
            @" select Id, Payload, CommitNumber, CommitSequence,[CommitStamp] from [DataProvider].[dbo].[CommandLog] where Id in @RequestIds order by CommitNumber, CommitSequence";

        public const string GetDataProviderStatistics =
            "select (select Convert(VARCHAR, cast(cast(avg(cast(CAST(ElapsedTime as datetime) as float)) as datetime) as time),20) from [Monitoring].[dbo].[MonitoringDataProvider] where [Action] = 'Response' and [Date] >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND [Date] < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)) AvgerageRequestTime, (select count(RequestId) FROM [Monitoring].[dbo].[MonitoringDataProvider] where ([Action] = 'Request') and [Date] >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND [Date] < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)) TotalRequests, (select count(RequestId) FROM [Monitoring].[dbo].[MonitoringDataProvider] where ([Action] = 'Response') and [Date] >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND [Date] < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)) TotalResponses, isnull((select count([state]) ErrorCount from [Billing].[dbo].[DataProviderTransaction] where ([State] <> 'Successful') and [Date] >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND [Date] < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)), 0) TotalErrors";

        public const string GetNumberOfErrorsPerRequest =
            "select count([state]) ErrorCount, RequestId from [Billing].[dbo].[DataProviderTransaction] where ([State] <> 'Successful') and RequestId in @RequestIds group by RequestId";
    }
}