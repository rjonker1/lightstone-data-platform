using System;
using System.Runtime.Serialization;

namespace Lim.Schedule.Core.Identifiers
{
    [DataContract]
    public class FlatFilePullIntegration
    {

        public FlatFilePullIntegration(Guid key, FlatFileIndentifier file, bool needToUnzip)
        {
            Key = key;
            File = file;
            NeedToUnzip = needToUnzip;
        }

        [DataMember]
        public Guid Key { get; private set; }

        [DataMember]
        public bool NeedToUnzip { get; private set; }

        [DataMember]
        public FlatFileIndentifier File { get; private set; }
    }

    [DataContract]
    public class FlatFilePushIntegration
    {

        public FlatFilePushIntegration(Guid key, FlatFileIndentifier file, bool needToUnzip)
        {
            Key = key;
            File = file;
            NeedToUnzip = needToUnzip;
        }

        [DataMember]
        public Guid Key { get; private set; }

        [DataMember]
        public bool NeedToUnzip { get; private set; }

        [DataMember]
        public FlatFileIndentifier File { get; private set; }
    }
}