using System;
using System.Collections.Generic;
using System.Configuration;
using Castle.Core;
using Castle.Windsor;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Testing;
using FluentNHibernate.Testing.Values;
using NHibernate;
using UserManagement.Api.Installers;
using UserManagement.Domain.Core.Entities;
using Xunit.Extensions;
using Configuration = NHibernate.Cfg.Configuration;

namespace UserManagement.Domain.Entities.Tests
{
    public class when_creaing_a_new_user : Specification
    {
        private ISession _session;
        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Kernel.ComponentModelCreated += OverrideContainerLifestyle;
            container.Install(new NHibernateInstaller());
            var configuration = container.Resolve<Configuration>();
            configuration.SetProperty("cache.provider_class", "NHibernate.Cache.NoCacheProvider, NHibernate.Cache");
            configuration.SetProperty("cache.use_second_level_cache", "false");
            configuration.SetProperty("cache.use_query_cache", "false");
            configuration.SetProperty("current_session_context_class", "thread_static");
            configuration.SetProperty("show_sql", "true");

            _session = container.Resolve<ISession>();
        }

        private void OverrideContainerLifestyle(ComponentModel model)
        {
            if (model.LifestyleType == LifestyleType.Undefined)
                model.LifestyleType = LifestyleType.Transient;

            if (model.LifestyleType == LifestyleType.PerWebRequest)
                model.LifestyleType = LifestyleType.Transient;
        }

        [Observation]
        public void should_add_user_and_relational_references()
        {
            new PersistenceSpecification<User>(_session)
                .CheckProperty(c => c.Id, Guid.NewGuid())
                .CheckProperty(c => c.UserName, "test")
                .CheckProperty(c => c.Password, "test")
                .CheckProperty(c => c.LastUpdateBy, "test")
                .CheckProperty(c => c.IsActive, true)
                .CheckProperty(c => c.FirstCreateDate, DateTime.Now.Date)
                .CheckProperty(c => c.LastUpdateDate, DateTime.Now.Date)
                .CheckReference(c => c.UserType, new UserType(Guid.NewGuid(), "Test"))
                .CheckComponentList(c => c.Roles, new List<Role> { new Role(new Guid("c628ba87-bab5-44a1-98f8-16ec5c560f85"), "Admin") })
                .VerifyTheMappings();
        }
    }
}
