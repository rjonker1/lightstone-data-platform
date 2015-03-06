using System;
using System.Collections.Generic;
using Workflow.Lace.Domain;
using Workflow.Lace.Mappers;

namespace Workflow.Lace.Repository
{
    internal class RepositoryMapper
    {
        private readonly IDictionary<Type, TypeMapper> _mappings = new Dictionary<Type, TypeMapper>();

        public RepositoryMapper()
        {
            _mappings = new Dictionary<Type, TypeMapper>()
            {
               {typeof(RequestHeader), new RequestHeaderTypeMapper()},
               {typeof(ResponseHeader), new ResponseHeaderTypeMapper()},
               {typeof(DataProviderRequest), new DataProviderRequestTypeMapper()},
               {typeof(DataProviderResponse), new DataProviderResponseTypeMapper()}
            };
        }

        public TypeMapper GetMapping(Type type)
        {
            if(!_mappings.ContainsKey(type))
                throw new Exception(string.Format("Could not find mapping for type {0}", type));
            return _mappings[type];
        }

        public TypeMapper GetMapping<T>(T instance)
        {
            var type = instance.GetType();
            return GetMapping(type);
        }
    }
}
