using System;
using System.Runtime.Serialization;

namespace DataProvider.Domain.Models
{
    [Serializable]
    [DataContract]
    public class DataProviderEventLog
    {
        private const string GetEventsForRequests =
            @"select Id, Payload, CommitNumber, CommitSequence,[CommitStamp] from DataProviderEventLog where Id in (select top 100 RequestId from DataProviderMonitoring where [action] = 'response' order by [date] desc) and (commandTypeId in (1,2,4,6,7)) order by CommitStamp, CommitNumber, CommitSequence";

        public static string SelectStatement()
        {
            return
                GetEventsForRequests;
        }
        

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public byte[] Payload { get; set; }

        [DataMember]
        public int CommitSequence { get; set; }

        [DataMember]
        public long CommitNumber { get; set; }

        [DataMember]
        public DateTime CommitStamp { get; set; }


    }

    [Serializable]
    [DataContract]
    public class DataProviderEventLogQuery
    {
        private const string GetEventsForArgument =
           @"select DataProviderEventLog.Id, Payload, CommitNumber, CommitSequence,[CommitStamp], dpm.Date, dpm.PackageVersion, dpm.PackageName, dpm.DataProviderCount, dpm.ElapsedTime, (select max(RowNumber) from (select row_number() over(order by dp.Id) as RowNumber  from DataProviderEventLog dp join DataProviderMonitoring m on m.RequestId = dp.Id where m.Action = 'Response' and (cast(dp.payload as varchar(max))) like '%' + @Argument + '%' group by dp.Id) as RowCountContainer) as RowsCount from DataProviderEventLog join (select dp.Id, max(dp.CommitNumber) as MaxCommitNumber from DataProviderEventLog dp join DataProviderMonitoring m on m.RequestId = dp.Id where m.Action = 'Response' and (cast(dp.payload as varchar(max))) like '%' + @Argument + '%' group by dp.Id order by MaxCommitNumber offset @Offset rows fetch next @Next rows only) as container on container.Id = DataProviderEventLog.Id join DataProviderMonitoring dpm on dpm.RequestId = DataProviderEventLog.Id where (commandTypeId in (1,2,4,6,7)) and dpm.Action = 'Response' and dpm.Date >= DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) -1, 0) AND dpm.Date < DATEADD(MONTH, DATEDIFF(MONTH, 0, GETDATE()) + 1, 0) order by CommitStamp desc, CommitNumber, CommitSequence";


        public static string SelectStatement()
        {
            return GetEventsForArgument;
        }

        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public byte[] Payload { get; set; }

        [DataMember]
        public int CommitSequence { get; set; }

        [DataMember]
        public long CommitNumber { get; set; }

        [DataMember]
        public DateTime CommitStamp { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public long PackageVersion { get; set; }
        [DataMember]
        public string PackageName { get; set; }
        [DataMember]
        public int DataProviderCount { get; set; }
        [DataMember]
        public string ElapsedTime { get; set; }
        [DataMember]
        public short RowsCount { get; set; }
       
    }
}