using System.Linq;
using AutoMapper;
using Castle.Windsor;
using PackageBuilder.Api.Installers;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMapper.Maps.DataFields
{
    public class when_mapping_to_a_single_data_field : Specification
    {
        private IDataField _dataField;
        public override void Observe()
        {
            var container = new WindsorContainer();

            container.Install(new ServiceLocatorInstaller(), new RepositoryInstaller(), new AutoMapperInstaller());

            _dataField = Mapper.Map<DataProviderFieldItemDto, IDataField>(DataFieldDtoMother.SpecificInformation);
        }

        [Observation]
        public void should_map_all_properties()
        {
            _dataField.Name.ShouldEqual("SpecificInformation");
            _dataField.Label.ShouldEqual("Label");
            _dataField.Definition.ShouldEqual("Definition");
            _dataField.CostOfSale.ShouldEqual(10d);
            _dataField.IsSelected.Value.ShouldBeTrue();
            _dataField.Industries.Count().ShouldEqual(2);
            _dataField.DataFields.Count().ShouldEqual(6);
            //_dataField.Type.ToString().ShouldEqual("System.String");
        }
    }
}