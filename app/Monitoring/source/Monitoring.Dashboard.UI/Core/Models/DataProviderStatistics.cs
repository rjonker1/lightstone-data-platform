﻿using System.Runtime.Serialization;

namespace Monitoring.Dashboard.UI.Core.Models
{
    [DataContract]
    public class DataProviderStatistics
    {
        private const string GetStatistics =
            @"select (select isnull(Convert(VARCHAR, cast(cast(avg(cast(CAST(SUBSTRING(ElapsedTime,0,9) as datetime) as float)) as datetime) as time),121),cast('00:00:00' as time)) from [Monitoring].[dbo].[DataProviderMonitoring] where [Action] = 'Response' and [Date] >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND [Date] < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)) AvgerageRequestTime, (select count(RequestId) FROM [Monitoring].[dbo].[DataProviderMonitoring] where ([Action] = 'Request') and [Date] >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND [Date] < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)) TotalRequests, (select count(RequestId) FROM [Monitoring].[dbo].[DataProviderMonitoring] where ([Action] = 'Response') and [Date] >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND [Date] < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)) TotalResponses, isnull((select count([state]) ErrorCount from [Billing].[dbo].[Transaction] where ([StateId] not in (1,7)) and [Date] >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) AND [Date] < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)), 0) TotalErrors";

        public DataProviderStatistics()
        {

        }

        public static string SelectStatement()
        {
            return GetStatistics;
        }

        [DataMember]
        public string AvgerageRequestTime { get; set; }

        [DataMember]
        public double TotalRequests { get; set; }

        [DataMember]
        public double TotalResponses { get; set; }

        [DataMember]
        public double TotalErrors { get; set; }
    }
}