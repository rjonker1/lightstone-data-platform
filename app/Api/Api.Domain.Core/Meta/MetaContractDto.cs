using System;
using System.Collections.Generic;

namespace Api.Domain.Core.Meta
{
    public class MetaContractDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<MetaPackageDto> Packages { get; set; }
    }
}