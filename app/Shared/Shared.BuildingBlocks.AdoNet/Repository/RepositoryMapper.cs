using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.BuildingBlocks.AdoNet.Mapping;

namespace Shared.BuildingBlocks.AdoNet.Repository
{
    public class RepositoryMapper : IRepositoryMapper
    {
        private readonly IHaveTypeMappings _mappings;

        public RepositoryMapper(IHaveTypeMappings mappings)
        {
            _mappings = mappings;
        }

        public TypeMapper GetMapping(Type type)
        {
            if (!_mappings.Mappings.ContainsKey(type))
                throw new Exception(string.Format("Could not find a mapping for type {0}", type));

            return _mappings.Mappings[type];
        }

        public TypeMapper GetMapping<TType>(TType instance)
        {
            var type = instance.GetType();

            return GetMapping(type);
        }
    }
}
