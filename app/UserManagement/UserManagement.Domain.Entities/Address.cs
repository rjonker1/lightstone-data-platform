using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Address : Entity
    {

        public string AddressType { get; set; }
        public string Line1 { get; set; }
        public string PostalCode { get; set; }
        public Guid ProvinceId { get; set; }
        public string Line2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public virtual Province Province { get; set; }
        public virtual ICollection<ProfileDetail> ProfileDetail { get; set; }
        public virtual ICollection<ProfileDetail> ProfileDetail1 { get; set; }

        public Address()
        {
            ProfileDetail = new HashSet<ProfileDetail>();
        }
    }
}