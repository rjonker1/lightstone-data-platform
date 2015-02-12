using System;
using System.Collections;
using System.Linq;
using AutoMapper;
using Castle.Windsor;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.Repositories;

namespace UserManagement.Api.Helpers.AutoMapper.Converters
{
    public class IdToEntityConverter : TypeConverter<Tuple<Guid, Type>, Entity>
    {
        private readonly IWindsorContainer _container;

        public IdToEntityConverter(IWindsorContainer container)
        {
            _container = container;
        }

        protected override Entity ConvertCore(Tuple<Guid, Type> source)
        {
            var executorType = typeof(IRepository<>).MakeGenericType(source.Item2);
            var repository = (IEnumerable)_container.Resolve(executorType);
            var entities = (from Entity item in repository where item.Id == source.Item1 select item);
            return entities.Any() ? entities.First() : null;
        }
    }
}