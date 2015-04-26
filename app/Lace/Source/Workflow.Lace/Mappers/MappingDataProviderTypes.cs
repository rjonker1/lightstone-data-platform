using System;
using System.Collections.Generic;
using Shared.BuildingBlocks.AdoNet.Mapping;
using Workflow.Lace.Domain;

namespace Workflow.Lace.Mappers
{
    public class MappingDataProviderTypes : IHaveTypeMappings
    {
        public Dictionary<Type, TypeMapper> Mappings { get; private set; }

        public MappingDataProviderTypes()
        {
            Mappings = new Dictionary<Type, TypeMapper>()
            {
                {typeof (DataProviderCommand), new DataProviderCommandMapper()}
            };
        }
    }
}
