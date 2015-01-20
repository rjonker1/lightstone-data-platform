using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Address : Entity
    {

        public virtual string AddressType { get; set; }
        public virtual string Line1 { get; set; }
        public virtual string PostalCode { get; set; }
        public virtual Guid ProvinceId { get; set; }
        public virtual string Line2 { get; set; }
        public virtual string City { get; set; }
        public virtual string Country { get; set; }

        public virtual Province Province { get; set; }
        public virtual ICollection<ProfileDetail> ProfileDetail { get; set; }
        public virtual ICollection<ProfileDetail> ProfileDetail1 { get; set; }

        public Address()
        {
            ProfileDetail = new HashSet<ProfileDetail>();
        }
    }
}