using System;
using System.Collections.Generic;
using Monitoring.Domain;
using Monitoring.Domain.Mappers;
using Shared.BuildingBlocks.AdoNet.Mapping;
using Workflow.Billing.Messages;
using Workflow.Billing.Messages.Mapping;
using Workflow.Lace.Domain;

namespace Workflow.Lace.Mappers
{
    public class MappingTransactionTypes : IHaveTypeMappings
    {
        public Dictionary<Type, TypeMapper> Mappings { get; private set; }

        public MappingTransactionTypes()
        {
            Mappings = new Dictionary<Type, TypeMapper>()
            {
                {typeof (InvoiceTransaction), new TransactionTypeMapper()},
                {typeof (DataProviderTransaction), new DataProviderTransactionTypeMapper()}
            };
        }
    }

    //public class MappingForMonitoringTypes : IHaveTypeMappings
    //{
    //    public Dictionary<Type, TypeMapper> Mappings { get; private set; }

    //    public MappingForMonitoringTypes()
    //    {
    //        Mappings = new Dictionary<Type, TypeMapper>()
    //        {
    //            {typeof (MonitoringDataProviderTransaction), new MonitoringDataProviderMapper()}
    //        };
    //    }
    //}
}
