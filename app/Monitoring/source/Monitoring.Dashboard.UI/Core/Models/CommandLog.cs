using System;
using System.Runtime.Serialization;

namespace Monitoring.Dashboard.UI.Core.Models
{
    [Serializable]
    [DataContract]
    public class DataProviderEventLog
    {
        private const string GetEventsForRequests =
            @"select Id, Payload, CommitNumber, CommitSequence,[CommitStamp] from DataProviderEventLog where Id in (select top 100 RequestId from DataProviderMonitoring where [action] = 'response' order by [date] desc) and (commandTypeId in (1,2,4,6,7)) order by CommitStamp, CommitNumber, CommitSequence";
            //@"select Id, Payload, CommitNumber, CommitSequence,[CommitStamp] from DataProviderEventLog where Id in (select top 100 RequestId from DataProviderMonitoring where [action] = 'response' order by [date] desc) order by CommitNumber, CommitSequence";

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

        public static string SelectStatement()
        {
            return
                GetEventsForRequests;
        }

    }
}