using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Castle.Windsor;
using Lace.Domain.Core.Entities;
using PackageBuilder.Api.Installers;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;
using PackageBuilder.TestHelper;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMapper.Maps
{
    public class when_mapping_a_complex_object_to_a_data_field : Specification
    {
        private IEnumerable<IDataField> _dataFields;
        
        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Kernel.ComponentModelCreated += OverrideHelper.OverrideContainerLifestyle;
            container.Install(new ServiceLocatorInstaller(), new BusInstaller(), new NEventStoreInstaller(), new NHibernateInstaller(), new RepositoryInstaller(), new AutoMapperInstaller());

            OverrideHelper.OverrideNhibernateCfg(container);

            var ivid = new IvidResponse();
            ivid.BuildSpecificInformation();

            _dataFields = Mapper.Map(ivid, ivid.GetType(), typeof(IEnumerable<IDataField>)) as IEnumerable<IDataField>;
        }

        [Observation]
        public void should_map_all_data_fields()
        {
            _dataFields.Count().ShouldEqual(31);
            _dataFields.First(x => x.Name == "CarFullname").Type.ToString().ShouldEqual(typeof(string).ToString());
            _dataFields.First(x => x.Name == "SpecificInformation").DataFields.Count().ShouldEqual(7);
        }
    }
}