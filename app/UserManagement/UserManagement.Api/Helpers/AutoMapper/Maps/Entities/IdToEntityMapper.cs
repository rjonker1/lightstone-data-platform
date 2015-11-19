using System;
using System.Linq;
using AutoMapper;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.Entities
{
    public class IdToEntityMapper : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            var entityTypes = typeof(Entity).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(Entity)));
            foreach (var entityType in entityTypes)
            {
                //Mapper.CreateMap(typeof(int), entityType).ConvertUsing(typeof(IdToEntityConverter<>));
                //var t = Activator.CreateInstance(typeof(IdToEntityConverter<>), typeof(int), entityType);
                //var generic = typeof(IdToEntityConverter<>);
                //var constructed = generic.MakeGenericType(entityType);

                var type1 = typeof(ITypeConverter<,>);
                var implementationType = type1.MakeGenericType(typeof(Guid), entityType);
                Mapper.CreateMap(typeof(Guid), entityType).ConvertUsing(implementationType);
            }
        }
    }
}