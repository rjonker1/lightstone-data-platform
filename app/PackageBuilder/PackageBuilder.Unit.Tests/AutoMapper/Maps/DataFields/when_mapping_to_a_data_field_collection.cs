using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Castle.Windsor;
using PackageBuilder.Api.Installers;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestHelper;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps.DataFields
{
    public class when_mapping_to_a_data_field_collection : Specification
    {
        private IEnumerable<IDataField> _dataFields;
        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Kernel.ComponentModelCreated += OverrideHelper.OverrideContainerLifestyle;

            container.Install(new NHibernateInstaller());
            OverrideHelper.OverrideNhibernateCfg(container);

            container.Install(new ServiceLocatorInstaller(), new BusInstaller(), new NEventStoreInstaller(), new RepositoryInstaller(), new AutoMapperInstaller());

            _dataFields = Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<DataField>>(new[] { DataFieldDtoMother.CarFullname, DataFieldDtoMother.CategoryCode, DataFieldDtoMother.SpecificInformation } );
        }

        [Observation]
        public void should_map_all_properties()
        {
            _dataFields.Count().ShouldEqual(3);
            _dataFields.First(x => x.Name == "SpecificInformation").DataFields.Count().ShouldEqual(6);
        }
    }
}