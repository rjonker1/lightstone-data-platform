using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackageBuilder.Domain.Models
{
    public class ReadDataProvider
    {
        public Guid Id { get; set; }
        public Guid DataProviderId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Owner { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
        public int Version { get; set; }
    }
}
