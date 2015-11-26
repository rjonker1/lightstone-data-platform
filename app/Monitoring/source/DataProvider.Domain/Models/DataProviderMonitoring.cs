using System;
using System.Runtime.Serialization;

namespace DataProvider.Domain.Models
{
    [DataContract]
    public class DataProviderMonitoring
    {
        private const string GetRequests =
           @"select top 100 RequestId, PackageName, PackageVersion, ElapsedTime, Action, Date,DataProviderCount from DataProviderMonitoring where [action] = 'response' order by [date] desc";

        private const string GetErrors =
            @"select RequestId, PackageName, PackageVersion, ElapsedTime, Action, Date,DataProviderCount from DataProviderMonitoring  where  RequestId in (select RequestId from [Billing].[dbo].[Transaction] t where (t.[StateId] not in (1,7)) and t.Date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) and t.Date < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)  group by RequestId) and [action] = 'response' order by [date] desc
select Id, Payload, CommitNumber, CommitSequence,[CommitStamp] from DataProviderEventLog where Id in (select RequestId from [Billing].[dbo].[Transaction] t where (t.[StateId] not in (1,7)) and t.Date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) and t.Date < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)  group by RequestId) and (commandTypeId in (1,2,4,6,7)) order by CommitStamp, CommitNumber, CommitSequence";

        public static string SelectStatement()
        {
            return GetRequests;
        }

        public static string SelectErrorsStatement()
        {
            return GetErrors;
        }

        [DataMember]
        public Guid RequestId { get; set; }

        [DataMember]
        public string PackageName { get; set; }

        [DataMember]
        public long PackageVersion { get; set; }

        [DataMember]
        public string ElapsedTime { get; set; }

        [DataMember]
        public string Action { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public int DataProviderCount { get; set; } 
      
    }


    [DataContract]
    public class DataProviderError
    {
        private const string GetErrors = @"select count([state]) ErrorCount, RequestId from [Billing].[dbo].[Transaction] where ([StateId] not in (1,7)) and Date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) and Date < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0) and RequestId in @RequestIds group by RequestId";

        //private const string GetErrorsForDate =
        //    @"select RequestId from [Billing].[dbo].[Transaction] t where (t.[StateId] not in (1,7)) and t.Date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()), 0) and t.Date < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0)  group by RequestId";

        public static string SelectStatement()
        {
            return GetErrors;
        }
        
        [DataMember]
        public Guid RequestId { get; set; }

        [DataMember]
        public int ErrorCount { get; set; }
    }
}