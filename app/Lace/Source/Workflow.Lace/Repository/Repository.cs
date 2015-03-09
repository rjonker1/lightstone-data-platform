using System;
using System.Data;

namespace Workflow.Lace.Repository
{
    public class Repository : IRepository
    {
        private readonly IDbConnection _connection;
        private readonly RepositoryMapper _mapper;

        public Repository(IDbConnection connection)
        {
            _connection = connection;
            _mapper = new RepositoryMapper();
        }

        public T Get<T>(Guid id) where T : class
        {
            var mapping = _mapper.GetMapping(typeof (T));
            return mapping.Get(_connection, id) as T;
        }

        public void Add<T>(T instance)
        {
            var mapping = _mapper.GetMapping(instance);
            mapping.Insert(_connection,instance);
        }
    }
}
