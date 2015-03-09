using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPlatform.Shared.Identifiers
{
    public class ResponseIdentifier
    {
        public ResponseIdentifier()
        {
            
        }

        public ResponseIdentifier(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
