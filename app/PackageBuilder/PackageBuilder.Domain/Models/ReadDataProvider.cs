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
        public string Name { get; set; }
        public int Version { get; set; }
    }
}
