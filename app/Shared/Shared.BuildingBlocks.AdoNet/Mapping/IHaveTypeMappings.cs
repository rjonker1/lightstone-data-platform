using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.BuildingBlocks.AdoNet.Mapping
{
    public interface IHaveTypeMappings
    {
        Dictionary<Type, TypeMapper> Mappings { get; }
    }
}
