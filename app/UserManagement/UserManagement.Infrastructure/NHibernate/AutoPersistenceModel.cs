﻿using System;
using FluentNHibernate.Automapping;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.NHibernate.Conventions;
using UserManagement.Infrastructure.NHibernate.MappingOverrides;

namespace UserManagement.Infrastructure.NHibernate
{
    public class AutoPersistenceModelConfiguration : DefaultAutomappingConfiguration
    {
       public override bool ShouldMap(Type type)
        {
            return type.IsSubclassOf(typeof (Entity));
        }

        public AutoPersistenceModel GetAutoPersistenceModel()
        {
            return AutoMap.AssemblyOf<User>(this)
                //.Where(type => type.IsSubclassOf(typeof (Entity)))
                .IncludeBase<NamedEntity>()
                .Conventions.AddFromAssemblyOf<PrimaryKeyConvention>()
                .UseOverridesFromAssemblyOf<UserMappingOverride>();
        }
    }
}