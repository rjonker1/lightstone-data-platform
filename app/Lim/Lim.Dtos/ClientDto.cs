using System;
using System.Runtime.Serialization;

namespace Lim.Dtos
{
    [DataContract]
    public class ClientDto
    {
        public ClientDto()
        {
            
        }

        private ClientDto(bool isActive, string name, string email, string contactPerson, string contactNumber,
            string createdBy)
        {
            IsActive = isActive;
            Name = name;
            Email = email;
            ContactPerson = contactPerson;
            ContactNumber = contactNumber;
            CreatedBy = createdBy;
        }

        private ClientDto(long id, bool isActive, string name, string email, string contactPerson, string contactNumber,
            string modifiedBy, DateTime? dateModified)
        {
            Id = id;
            IsActive = isActive;
            Name = name;
            Email = email;
            ContactPerson = contactPerson;
            ContactNumber = contactNumber;
            ModifiedBy = modifiedBy;
            DateModified = dateModified;
        }

        public static ClientDto Existing(long id, bool isActive, string name, string email, string contactPerson, string contactNumber,
            string modifiedBy, DateTime? dateModified)
        {
            return new ClientDto(id, isActive, name, email, contactPerson, contactNumber, modifiedBy, dateModified);
        }

        public static ClientDto Create()
        {
            return new ClientDto();
        }
            
        [DataMember]
        public long Id { get; private set; }
        [DataMember]
        public bool IsActive { get; private set; }
        [DataMember]
        public string Name { get; private set; }
        [DataMember]
        public string Email { get; private set; }
        [DataMember]
        public string ContactPerson { get; private set; }
        [DataMember]
        public string ContactNumber { get; private set; }
        [DataMember]
        public DateTime DateCreated { get; private set; }
        [DataMember]
        public string CreatedBy { get; private set; }
        [DataMember]
        public DateTime? DateModified { get; private set; }
        [DataMember]
        public string ModifiedBy { get; private set; }
    }
}