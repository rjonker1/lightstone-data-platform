using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Lim.Domain.Models
{
    [DataContract]
    public class Client
    {

        public const string Select = @"select c.* from Client c";

        public Client()
        {
            
        }

        private Client(bool isActive, string name, string email, string contactPerson, string contactNumber,
            string createdBy)
        {
            IsActive = isActive;
            Name = name;
            Email = email;
            ContactPerson = contactPerson;
            ContactNumber = contactNumber;
            CreatedBy = createdBy;
        }

        private Client(long id, bool isActive, string name, string email, string contactPerson, string contactNumber,
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

        //public static Client New(bool isActive, string name, string email, string contactPerson, string contactNumber,
        //    string createdBy)
        //{
        //    return new Client(isActive,name,email,contactPerson,contactPerson,createdBy);
        //}

        //public static Client Exisiting(long id, bool isActive, string name, string email, string contactPerson, string contactNumber,
        //    string modifiedBy)
        //{
        //    return new Client(id, isActive, name, email, contactPerson, contactNumber, modifiedBy);
        //}

        public Client(long id)
        {
            Id = id;
        }

        public static Client Create()
        {
            return new Client();
        }

        public static Client Existing(long id)
        {
            return new Client(id);
        }

        public static IEnumerable<Client> Get()
        {
            //TODO: get all clients
            return new List<Client>();
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