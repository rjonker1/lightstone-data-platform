using System;
using System.Linq;
using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Helpers.Extensions;
using Shared.Logging;
using UserManagement.Api.Helpers.AutoMapper.Converters;
using UserManagement.Api.Helpers.AutoMapper.Maps;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Installers
{
    public class AutoMapperInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            this.Info(() => "Attempting to install AutoMapperInstaller", SystemName.UserManagement);

            container.Register(Classes.FromAssemblyContaining<ICreateAutoMapperMaps>().BasedOn(typeof(ITypeConverter<,>)).WithServiceAllInterfaces().LifestyleTransient());
            container.Register(Classes.FromAssemblyContaining<ICreateAutoMapperMaps>().BasedOn<ICreateAutoMapperMaps>().WithServiceAllInterfaces().LifestyleTransient());
            RegisterIdToEntityConverters(container);
            Mapper.Configuration.ConstructServicesUsing(container.Resolve);
            foreach (var map in container.ResolveAll<ICreateAutoMapperMaps>())
                map.CreateMaps();

            this.Info(() => "Successfully installed AutoMapperInstaller", SystemName.UserManagement);
        }

        private static void RegisterIdToEntityConverters(IWindsorContainer container)
        {
            var entityTypes = typeof(Entity).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(Entity)));
            foreach (var entityType in entityTypes)
            {
                var generic = typeof(IdToEntityConverter<>);
                var constructed = generic.MakeGenericType(entityType);

                var typeConverterType = typeof(ITypeConverter<,>);
                var typeConverterGenericType = typeConverterType.MakeGenericType(typeof(Guid), entityType);
                container.Register(Component.For(typeConverterGenericType).ImplementedBy(constructed).LifestyleTransient());
            }
        }
    }
}