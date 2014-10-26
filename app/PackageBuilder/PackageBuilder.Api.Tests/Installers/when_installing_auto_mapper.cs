﻿using Castle.Windsor;
using MemBus;
using PackageBuilder.Api.Installers;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.Installers
{
    public class when_installing_auto_mapper : Specification
    {
        readonly IWindsorContainer _container = new WindsorContainer();

        public override void Observe()
        {
            _container.Install(new AutoMapperInstaller());
        }

        [Observation]
        public void should_resolve_IBus()
        {
            _container.Resolve<IBus>().ShouldNotBeNull();
        }
    }
}