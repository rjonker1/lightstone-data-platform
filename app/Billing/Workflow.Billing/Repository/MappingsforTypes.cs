using System;
using System.Collections.Generic;
using Workflow.Billing.Domain;

namespace Workflow.Billing.Repository
{
    public class MappingsforTypes : IHaveTypeMappings
    {
        public Dictionary<Type, TypeMapper> Mappings { get; private set; }

        public MappingsforTypes()
        {
            Mappings =  new Dictionary<Type, TypeMapper>()
            {
                {typeof (InvoiceTransaction), new TransactionTypeMapper()} 
            };
        }
    }
}

