using System;
using System.Runtime.Serialization;

namespace Workflow.Lace.Identifiers
{
    [Serializable]
    [DataContract]
    public class ConnectionTypeIdentifier
    {
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Connection { get; set; }

        public ConnectionTypeIdentifier(string connection, string type)
        {
            Connection = connection;
            Type = type;
        }

        public ConnectionTypeIdentifier(string connection)
        {
            Connection = connection;
        }

        public ConnectionTypeIdentifier ForDatabaseType()
        {
            Type = "Database";
            return this;
        }

        public ConnectionTypeIdentifier ForWebApiType()
        {
            Type = "Web Api";
            return this;
        }

        public ConnectionTypeIdentifier ForFtpApiType()
        {
            Type = "Ftp Api";
            return this;
        }

        public ConnectionTypeIdentifier ForFlatFileType()
        {
            Type = "Flat File";
            return this;
        }

        public ConnectionTypeIdentifier ForCacheType()
        {
            Type = "Cache";
            return this;
        }

        public ConnectionTypeIdentifier()
        {
            
        }
    }
}
