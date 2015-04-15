using System;
using System.Collections.Generic;
using Shared.BuildingBlocks.AdoNet.Mapping;
using Workflow.Billing.Messages;
using Workflow.Billing.Messages.Mapping;
using Workflow.Lace.Domain;

namespace Workflow.Lace.Mappers
{
    public class MappingForTypes : IHaveTypeMappings
    {
        public Dictionary<Type, TypeMapper> Mappings { get; private set; }

        public MappingForTypes()
        {
            Mappings = new Dictionary<Type, TypeMapper>()
            {
                {typeof (InvoiceTransaction), new TransactionTypeMapper()},
                {typeof(DataProviderTransaction), new DataProviderTransactionTypeMapper()}
            };
        }
    }
}
