using System;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.NHibernate.Attributes;

namespace UserManagement.Domain.Entities
{
    public class ClientAccountNumber : AccountNumber
    {
        [DoNotMap]
        public virtual Client Client { get; set; } // todo change to protected internal set

        public override string ToString()
        {
            if (Client == null) throw new ArgumentNullException("ClientAccountNumber cannot be generated - Client association is null");
            return "{0}{1}".FormatWith(Client.Name.Substring(0, 3), (Id + "").PadLeft(5, '0'));
        }
    }
}