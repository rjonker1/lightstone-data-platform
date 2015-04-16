using System;
using System.Runtime.Serialization;
using Monitoring.Dashboard.UI.Core.Extensions;

namespace Monitoring.Dashboard.UI.Core.Models
{
    [Serializable]
    [DataContract]
    public class MonitoringDataProvider
    {
        [DataMember]
        public Guid RequestId { get; set; }

        [DataMember]
        public string SearchType { get; set; }

        [DataMember]
        public string SearchTerm { get; set; }

        [DataMember]
        public string ElapsedTime { get; set; }

        [DataMember]
        public string Action { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public string Payload { get; private set; }

        [DataMember]
        public Results Results { get; private set; }

        [DataMember]
        public bool HasErrors
        {
            get
            {
                return false;
            }
        }

        public void GetResults()
        {
            Results = ElapsedTime.JsonToObject<Results>();
        }
    }

    //[DataContract]
    //public class CommandDetail
    //{
    //    [DataMember]
    //    public int Order { get; set; }

    //    [DataMember]
    //    public int SubOrder { get; set; }
    //}

    //[DataContract]
    //public class PackageInformation
    //{
    //    [DataMember]
    //    public EntryPointReceivedRequest EntryPointReceivedRequest { get; set; }
    //}

    //[DataContract]
    //public class EntryPointReceivedRequest
    //{
    //    [DataMember]
    //    public Payload Payload { get; set; }
    //}

    //[DataContract]
    //public class Payload
    //{
    //    [DataMember]
    //    public Package Package { get; set; }
    //    [DataMember]
    //    public string SearchTerm { get; set; }
    //    [DataMember]
    //    public string RequestDate { get; set; }
    //}

    //[DataContract]
    //public class Package
    //{
    //    [DataMember]
    //    public string Name { get; set; }
    //}

    //[DataContract]
    //public class Errors
    //{
    //    [DataMember]
    //    public ThrowError ThrowError { get; set; } 
    //}

    //[DataContract]
    //public class ThrowError
    //{
    //    [DataMember]
    //    public int DataProviderCommandSource { get; set; }
    //    [DataMember]
    //    Guid Id { get; set; }
    //}

    //[DataContract]
    //public class PerformanceMetaData
    //{

    //    [DataMember]
    //    public EntryPointProcessedAndReturningRequest EntryPointProcessedAndReturningRequest { get; set; }
    //}

    //[DataContract]
    //public class EntryPointProcessedAndReturningRequest
    //{
    //    [DataMember]
    //    public MetaData MetaData { get; set; }
    //}

    //[DataContract]
    //public class MetaData
    //{
    //    [DataMember]
    //    public Results Results { get; set; }
    //}

    [DataContract]
    public class Results
    {
        [DataMember]
        public string ElapsedTime { get; set; }

        [DataMember]
        public string Name { get; set; }
    }
}