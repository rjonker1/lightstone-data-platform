using System;
using System.Runtime.Serialization;

namespace Lim.Schedule.Core.Identifiers
{
    [DataContract]
    public class FlatFilePullIntegration
    {

        public FlatFilePullIntegration(Guid key, FlatFileIndentifier file, DirectoryWatcherIndentifier watcher, bool needToUnzip)
        {
            Key = key;
            File = file;
            NeedToUnzip = needToUnzip;
            Watcher = watcher;
        }

        public void Pull()
        { }


        [DataMember]
        public Guid Key { get; private set; }

        [DataMember]
        public bool NeedToUnzip { get; private set; }

        [DataMember]
        public FlatFileIndentifier File { get; private set; }
        [DataMember]
        public DirectoryWatcherIndentifier Watcher { get; private set; }
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

        public void Push()
        { }

        [DataMember]
        public Guid Key { get; private set; }

        [DataMember]
        public bool NeedToUnzip { get; private set; }

        [DataMember]
        public FlatFileIndentifier File { get; private set; }
    }
}