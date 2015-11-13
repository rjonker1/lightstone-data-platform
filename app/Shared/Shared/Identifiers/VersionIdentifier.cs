using System;
using System.Runtime.Serialization;

namespace DataPlatform.Shared.Identifiers
{
    [Serializable]
    [DataContract]
    public class VersionIdentifier
    {
        [DataMember]
        public long Number { get; set; }
        [DataMember]
        public DateTime Date { get; set; }

        public VersionIdentifier()
        {
        }

        public VersionIdentifier(long number)
        {
            Number = number;
        }

        public VersionIdentifier(long number, DateTime date)
        {
            Number = number;
            Date = date;
        }

        protected bool Equals(VersionIdentifier other)
        {
            return Number == other.Number && Date.Equals(other.Date);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((VersionIdentifier) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Number.GetHashCode()*397) ^ Date.GetHashCode();
            }
        }
    }
}