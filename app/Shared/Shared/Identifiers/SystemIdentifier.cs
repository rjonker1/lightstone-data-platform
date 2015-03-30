using System;
using System.Runtime.Serialization;

namespace DataPlatform.Shared.Identifiers
{
    [Serializable]
    [DataContract]
    public class SystemIdentifier
    {
        public SystemIdentifier()
        {
        }

        public SystemIdentifier(string systemName) : this(systemName, ServerIdentifier.Create())
        {
        }

        public SystemIdentifier(string systemName, ServerIdentifier server)
        {
            Name = systemName;
            Server = server;
        }

        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public ServerIdentifier Server { get; set; }

        public static SystemIdentifier CreateApi()
        {
            return new SystemIdentifier("API", ServerIdentifier.Create());
        }

        protected bool Equals(SystemIdentifier other)
        {
            return string.Equals(Name, other.Name) && Equals(Server, other.Server);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SystemIdentifier) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0)*397) ^ (Server != null ? Server.GetHashCode() : 0);
            }
        }
    }
}