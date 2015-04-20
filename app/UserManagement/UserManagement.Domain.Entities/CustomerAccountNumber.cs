using System;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.NHibernate.Attributes;

namespace UserManagement.Domain.Entities
{
    public class CustomerAccountNumber : AccountNumber
    {
        [DoNotMap]
        public virtual Customer Customer { get; set; }

        public override string ToString()
        {
            if (Customer == null) throw new ArgumentNullException("CustomerAccountNumber cannot be generated - Customer association is null");
            return "{0}{1}".FormatWith(Customer.Name.Substring(0, 3), (Id + "").PadLeft(5, '0'));
        }
    }
}