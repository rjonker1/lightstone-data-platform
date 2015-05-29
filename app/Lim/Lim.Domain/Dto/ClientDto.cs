using System;
using System.Runtime.Serialization;

namespace Lim.Domain.Dto
{
    [DataContract]
    public class ClientDto
    {

        public const string SelectAll = @"select c.* from Client c";
        public const string Select = @"select c.* from Client c where c.Id = @Id";

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
            string modifiedBy)
        {
            Id = id;
            IsActive = isActive;
            Name = name;
            Email = email;
            ContactPerson = contactPerson;
            ContactNumber = contactNumber;
            ModifiedBy = modifiedBy;
        }


        public ClientDto(long id)
        {
            Id = id;
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
        public DateTime DateModified { get; private set; }
        [DataMember]
        public string ModifiedBy { get; private set; }

    }
}