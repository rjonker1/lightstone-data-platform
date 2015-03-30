using System;
using System.Collections.Generic;
using Workflow.Billing.Repository;
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
                //{typeof (InvoiceTransaction), new TransactionTypeMapper()}
                {typeof(DataProviderTransaction), new DataProviderTransactionTypeMapper()}
            };
        }
    }
}
