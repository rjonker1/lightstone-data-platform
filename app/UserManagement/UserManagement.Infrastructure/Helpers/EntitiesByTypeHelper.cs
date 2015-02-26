using System;
using System.Linq;
using Castle.Windsor;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.Helpers;
using UserManagement.Domain.Core.Repositories;

namespace UserManagement.Infrastructure.Helpers
{
    public interface IRetrieveEntitiesByType
    {
        IQueryable GetEntities(Type type);
        IQueryable<NamedEntity> GetNamedEntities(Type type);
        IQueryable<NamedEntity> GetNamedEntities(Type type, string name);
        PagedList<NamedEntity> GetNamedEntities(Type type, string name, int pageIndex, int pageSize);
    }

    public class EntitiesByTypeHelper : IRetrieveEntitiesByType
    {
        private readonly IWindsorContainer _container;

        public EntitiesByTypeHelper(IWindsorContainer container)
        {
            _container = container;
        }

        public IQueryable GetEntities(Type type)
        {
            var executorType = typeof(IRepository<>).MakeGenericType(type);
            return (IQueryable)_container.Resolve(executorType);
        }

        public IQueryable<NamedEntity> GetNamedEntities(Type type)
        {
            var executorType = typeof(INamedEntityRepository<>).MakeGenericType(type);
            var namedEntities = (IQueryable)_container.Resolve(executorType);
            return (from NamedEntity item in namedEntities select item);
        }

        public IQueryable<NamedEntity> GetNamedEntities(Type type, string name)
        {
            return GetNamedEntities(type).Where(x => (x.Name + "").Trim().ToLower().StartsWith((name + "").Trim().ToLower()));
        }

        public PagedList<NamedEntity> GetNamedEntities(Type type, string name, int pageIndex, int pageSize)
        {
            return !string.IsNullOrEmpty(name)
                ? new PagedList<NamedEntity>(GetNamedEntities(type), pageIndex, pageSize, x => (x.Name + "").Trim().ToLower().StartsWith((name + "").Trim().ToLower()))
                : new PagedList<NamedEntity>(GetNamedEntities(type), pageIndex, pageSize);
        }
    }
}