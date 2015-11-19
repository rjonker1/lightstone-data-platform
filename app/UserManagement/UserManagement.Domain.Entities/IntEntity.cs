using System.Runtime.Serialization;

namespace UserManagement.Domain.Entities
{
    [DataContract]
    public abstract class IntEntity
    {
        public virtual int Id { get; protected internal set; }
    }
}