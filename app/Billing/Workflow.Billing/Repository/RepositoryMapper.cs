using System;
using System.Collections.Generic;
using Workflow.Billing.Domain;

namespace Workflow.Billing.Repository
{
    internal class RepositoryMapper
    {
        private readonly Dictionary<Type, TypeMapper> mappings = new Dictionary<Type, TypeMapper>();

        public RepositoryMapper()
        {
            mappings = new Dictionary<Type, TypeMapper>()
            {
                {typeof (InvoiceTransaction), new TransactionTypeMapper()},
                {typeof (InvoiceResponse), new ResponseTypeMapper()}
            };
        }

        public TypeMapper GetMapping(Type type)
        {
            if (!mappings.ContainsKey(type))
                throw new Exception(string.Format("Could not find a mapping for type {0}", type));

            return mappings[type];
        }

        public TypeMapper GetMapping<TType>(TType instance)
        {
            var type = instance.GetType();

            return GetMapping(type);
        }
    }
}