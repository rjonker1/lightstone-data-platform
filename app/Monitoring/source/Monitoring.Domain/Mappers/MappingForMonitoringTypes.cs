using System;
using System.Collections.Generic;
using Shared.BuildingBlocks.AdoNet.Mapping;

namespace Monitoring.Domain.Mappers
{
    public class MappingForMonitoringTypes : IHaveTypeMappings
    {
        public Dictionary<Type, TypeMapper> Mappings { get; private set; }

        public MappingForMonitoringTypes()
        {
            Mappings = new Dictionary<Type, TypeMapper>()
            {
                {typeof (MonitoringDataProviderTransaction), new MonitoringDataProviderMapper()},
                {typeof (MonitoringApiRequest), new MonitoringApiRequestMapper()},
                {typeof (MonitoringDataProviderExecution), new MonitoringDataProviderExecutionMapper()},
                {typeof (MonitoringDataProviderRequestField), new MonitoringDataProviderRequestFieldMapper()}
            };
        }
    }
}