using System.Runtime.Serialization;

namespace DataProvider.Domain.Models
{
    [DataContract]
    public class DataProviderIndicators
    {
        //private const string GetStatistics =
        //    @"select (select isnull(Convert(VARCHAR, cast(cast(avg(cast(CAST(SUBSTRING(ElapsedTime,0,9) as datetime) as float)) as datetime) as time),121),cast('00:00:00' as time)) from [Monitoring].[dbo].[DataProviderMonitoring] where [Action] = 'Response' and [Date] >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND [Date] < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)) AvgerageRequestTime, (select count(RequestId) FROM [Monitoring].[dbo].[DataProviderMonitoring] where ([Action] = 'Request') and [Date] >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND [Date] < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)) TotalRequests, (select count(RequestId) FROM [Monitoring].[dbo].[DataProviderMonitoring] where ([Action] = 'Response') and [Date] >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND [Date] < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)) TotalResponses, isnull((select count([state]) ErrorCount from [Billing].[dbo].[Transaction] where ([StateId] not in (1,7)) and [Date] >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND [Date] < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)), 0) TotalErrors";

        private const string GetIndicators = @"--avg response time, total errors, total requests, total responses
  select (select isnull(Convert(VARCHAR, cast(cast(avg(cast(CAST(SUBSTRING(ElapsedTime,0,9) as datetime) as float)) as datetime) as time),121),cast('00:00:00' as time)) from [Monitoring].[dbo].[DataProviderMonitoring] where [Action] = 'Response' and [Date] >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND [Date] < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)) AverageResponseTime, (select count(RequestId) FROM [Monitoring].[dbo].[DataProviderMonitoring] where ([Action] = 'Request') and [Date] >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND [Date] < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)) TotalRequests, (select count(RequestId) FROM [Monitoring].[dbo].[DataProviderMonitoring] where ([Action] = 'Response') and [Date] >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND [Date] < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)) TotalResponses, isnull((select count([state]) ErrorCount from [Billing].[dbo].[Transaction] where ([StateId] not in (1,7)) and [Date] >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND [Date] < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)), 0) TotalErrors
  --Total request per DP
  select count(m.Id) as [Count], m.DataProviderId from DataProviderEventLog m where m.CommandTypeId = 6 and DataProviderId <> 6 and m.CommitStamp >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND m.CommitStamp < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0) group by m.DataProviderId, m.DataProviderId
    --Avg Response time per DP
  select m.Payload, m.DataProviderId from [dbo].[DataProviderEventLog] m where m.CommandTypeId = 6 and m.CommitStamp >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND m.CommitStamp < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)
    --Total VIN Requests, LIC Requests, etc.
  select distinct m.Id as RequestId, m.payload from [dbo].[DataProviderEventLog] m where m.CommandTypeId = 5 and m.DataProviderId = 6 and m.CommitStamp >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND m.CommitStamp < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)
";

        public DataProviderIndicators()
        {

        }

        public static string SelectStatement()
        {
            return GetIndicators;
        }
    }
}