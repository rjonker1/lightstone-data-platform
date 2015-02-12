using System;
using Castle.Windsor;
using UserManagement.Domain.Core.Repositories;

namespace UserManagement.Infrastructure.Helpers
{
    public interface IRetrieveEntitiesByType
    {
        System.Linq.IQueryable GetEntities(Type type);
        System.Linq.IQueryable GetNamedEntities(Type type);
    }

    public class EntitiesByTypeHelper : IRetrieveEntitiesByType
    {
        private readonly IWindsorContainer _container;

        public EntitiesByTypeHelper(IWindsorContainer container)
        {
            _container = container;
        }

        public System.Linq.IQueryable GetEntities(Type type)
        {
            var executorType = typeof(IRepository<>).MakeGenericType(type);
            return (System.Linq.IQueryable)_container.Resolve(executorType);
        }

        public System.Linq.IQueryable GetNamedEntities(Type type)
        {
            var executorType = typeof(INamedEntityRepository<>).MakeGenericType(type);
            return (System.Linq.IQueryable)_container.Resolve(executorType);
        }
    }
}