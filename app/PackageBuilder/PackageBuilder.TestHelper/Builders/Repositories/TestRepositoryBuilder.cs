using DataPlatform.Shared.Entities;
using Shared.Public.TestHelpers.Repositories;

namespace PackageBuilder.TestHelper.Builders.Repositories
{
    public class TestRepositoryBuilder<TRepo, TEntity>
        where TRepo : CannedRepository<TEntity>, new() 
        where TEntity : IEntity
    {
        private TEntity[] _entities;
        public TRepo Build()
        {
            var repository = new TRepo();
            repository.Add(_entities);
            return repository;
        }

        public TestRepositoryBuilder<TRepo, TEntity> WithEntities(params TEntity[] entities)
        {
            _entities = entities;
            return this;
        }
    }
}