using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPlatform.Shared.Identifiers
{
    public class ContractIdentifier
    {
          public ContractIdentifier()
        {
        }

          public ContractIdentifier(Guid id, VersionIdentifier version)
        {
            Id = id;
            Version = version;
        }

        public Guid Id { get; set; }
        public VersionIdentifier Version { get; set; }
    }
}
