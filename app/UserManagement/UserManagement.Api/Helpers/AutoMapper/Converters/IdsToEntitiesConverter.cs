using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Castle.Windsor;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.Repositories;

namespace UserManagement.Api.Helpers.AutoMapper.Converters
{
    public class IdsToEntitiesConverter : TypeConverter<Tuple<IEnumerable<Guid>, Type>, HashSet<Entity>>
    {
        private readonly IWindsorContainer _container;

        public IdsToEntitiesConverter(IWindsorContainer container)
        {
            _container = container;
        }

        protected override HashSet<Entity> ConvertCore(Tuple<IEnumerable<Guid>, Type> source)
        {
            var executorType = typeof(IRepository<>).MakeGenericType(source.Item2);
            var repository = (IEnumerable)_container.Resolve(executorType);
            var entities = (from Entity item in repository select item).Where(x => source.Item1.Contains(x.Id));
            return new HashSet<Entity>(entities);
        }
    }
}