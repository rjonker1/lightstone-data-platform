using System;
using System.Linq;
using Castle.Windsor;
using DataPlatform.Shared.Helpers;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Infrastructure.Helpers
{
    public interface IEntityByTypeRepository
    {
        IQueryable<Entity> GetEntities(Type type);
        IQueryable<NamedEntity> GetNamedEntities(Type type);
        IQueryable<NamedEntity> GetNamedEntities(Type type, string name);
        PagedList<NamedEntity> GetNamedEntities(Type type, string name, int pageIndex, int pageSize);
        bool Exists(Type type, Guid id, string value);
        IQueryable<ValueEntity> GetValueEntities(Type type);
        IQueryable<ValueEntity> GetValueEntities(Type type, string value);
        PagedList<ValueEntity> GetValueEntities(Type type, string value, int pageIndex, int pageSize);
        IQueryable<NamedEntity> GetIndustryEntities(Type type, string name, Guid[] industries);
        IQueryable<EntityNote> GetEntityNotes(Type type);
    }

    public class EntityByTypeRepository : IEntityByTypeRepository
    {
        private readonly IWindsorContainer _container;

        public EntityByTypeRepository(IWindsorContainer container)
        {
            _container = container;
        }

        public IQueryable<Entity> GetEntities(Type type)
        {
            var executorType = typeof(IRepository<>).MakeGenericType(type);
            var namedEntities = (IQueryable)_container.Resolve(executorType);
            return (from Entity item in namedEntities select item);
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

        public IQueryable<NamedEntity> GetIndustryEntities(Type type, string name, Guid[] industries)
        {
            //return null;
            return GetNamedEntities(type).Where(x => (x.Name + "").Trim().ToLower().StartsWith((name + "").Trim().ToLower()) && ((IIndustry)x).Industries.Any(ind => industries.Contains(ind.IndustryId)));
        }

        public PagedList<NamedEntity> GetNamedEntities(Type type, string name, int pageIndex, int pageSize)
        {
            return !string.IsNullOrEmpty(name)
                ? new PagedList<NamedEntity>(GetNamedEntities(type), pageIndex, pageSize, x => (x.Name + "").Trim().ToLower().StartsWith((name + "").Trim().ToLower()))
                : new PagedList<NamedEntity>(GetNamedEntities(type), pageIndex, pageSize);
        }

        public bool Exists(Type type, Guid id, string value)
        {
            return GetValueEntities(type).Any(x => x.Id != id && (x.Value + "").Trim().ToLower().StartsWith((value + "").Trim().ToLower()));
        }

        public IQueryable<ValueEntity> GetValueEntities(Type type)
        {
            var executorType = typeof(IValueEntityRepository<>).MakeGenericType(type);
            var namedEntities = (IQueryable)_container.Resolve(executorType);
            return (from ValueEntity item in namedEntities select item);
        }

        public IQueryable<ValueEntity> GetValueEntities(Type type, string value)
        {
            return GetValueEntities(type).Where(x => (x.Value + "").Trim().ToLower().StartsWith((value + "").Trim().ToLower()));
        }

        public PagedList<ValueEntity> GetValueEntities(Type type, string value, int pageIndex, int pageSize)
        {
            var predicate = PredicateBuilder.False<ValueEntity>();
            predicate = predicate.Or(x => (x.Value + "").Trim().ToLower().StartsWith((value + "").Trim().ToLower()));
            return new PagedList<ValueEntity>(GetValueEntities(type), pageIndex, pageSize, predicate);
        }

        public IQueryable<EntityNote> GetEntityNotes(Type type)
        {
            var executorType = typeof(IEntityNoteRepository<>).MakeGenericType(type);
            var entities = (IQueryable)_container.Resolve(executorType);
            return (from EntityNote item in entities select item);
        }
    }
}