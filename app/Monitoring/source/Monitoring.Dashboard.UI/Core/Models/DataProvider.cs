using System;
using System.Runtime.Serialization;

namespace Monitoring.Dashboard.UI.Core.Models
{
    [DataContract]
    public class DataProvider
    {
        private const string GetRequests =
           @"select top 100 RequestId, PackageName, PackageVersion, ElapsedTime, Action, Date,DataProviderCount from DataProviderMonitoring where [action] = 'response' order by [date] desc";


        public static string SelectStatement()
        {
            return GetRequests;
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
    public class Results
    {
        [DataMember]
        public string ElapsedTime { get; set; }

        [DataMember]
        public string Name { get; set; }
    }

    [DataContract]
    public class DataProviderError
    {
        private const string GetErrors = @"select count([state]) ErrorCount, RequestId from [Billing].[dbo].[DataProviderTransaction] where ([State] <> 'Successful') and RequestId in @RequestIds group by RequestId";

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