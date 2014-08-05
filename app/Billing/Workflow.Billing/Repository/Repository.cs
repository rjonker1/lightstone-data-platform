using System;
using System.Data;

namespace Workflow.Billing.Repository
{
    public class Repository : IRepository
    {
        private readonly IDbConnection connection;
        private readonly RepositoryMapper mapper;

        public Repository(IDbConnection connection)
        {
            mapper = new RepositoryMapper();
            this.connection = connection;
        }

        public TType Get<TType>(Guid id) where TType : class
        {
            var mapping = mapper.GetMapping(typeof(TType));

            return mapping.Get(connection, id) as TType;

        }

        public void Add<TType>(TType instance)
        {
            var mapping = mapper.GetMapping(instance);

            mapping.Insert(connection, instance);
        }
    }
}