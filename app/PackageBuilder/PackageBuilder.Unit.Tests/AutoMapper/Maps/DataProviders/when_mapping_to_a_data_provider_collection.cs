using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Castle.Windsor;
using PackageBuilder.Api.Installers;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.TestHelper;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataProviders
{
    public class when_mapping_to_a_data_provider_collection : Specification
    {
        private IEnumerable<IDataProvider> _dataProviders;

        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Kernel.ComponentModelCreated += OverrideHelper.OverrideContainerLifestyle;
            container.Install(new ServiceLocatorInstaller(), new BusInstaller(), new NEventStoreInstaller(), new NHibernateInstaller(), new RepositoryInstaller(), new AutoMapperInstaller());

            OverrideHelper.OverrideNhibernateCfg(container);

            _dataProviders = Mapper.Map<IEnumerable<DataProviderDto>, IEnumerable<DataProvider>>(new[] { DataProviderDtoMother.Ivid, DataProviderDtoMother.IvidTitleHolder });
        }

        [Observation]
        public void should_map_all_fields()
        {
            _dataProviders.Count().ShouldEqual(2);
        }
    }
}