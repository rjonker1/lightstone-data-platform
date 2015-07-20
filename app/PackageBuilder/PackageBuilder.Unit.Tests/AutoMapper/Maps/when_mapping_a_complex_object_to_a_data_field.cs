using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Castle.Windsor;
using Lace.Domain.Core.Entities;
using PackageBuilder.Api.Installers;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.TestHelper;
using Xunit.Extensions;

namespace PackageBuilder.Unit.Tests.AutoMapper.Maps
{
    public class when_mapping_a_complex_object_to_a_data_field : Specification
    {
        private IEnumerable<IDataField> _dataFields;
        
        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Install(new ServiceLocatorInstaller(), new BusInstaller(), new NEventStoreInstaller(), new NHibernateInstaller(), new RepositoryInstaller(), new AutoMapperInstaller());

            OverrideHelper.OverrideNhibernateCfg(container);

            var ivid = new IvidResponse();
            ivid.BuildSpecificInformation();

            _dataFields = Mapper.Map(ivid, ivid.GetType(), typeof(IEnumerable<DataField>)) as IEnumerable<DataField>;
        }

        [Observation]
        public void should_map_all_data_fields()
        {
            _dataFields.Count().ShouldEqual(32);
            _dataFields.FirstOrDefault(x => x.Name == "CarFullname").Type.ShouldEqual(typeof(string).ToString());
            _dataFields.First(x => x.Name == "SpecificInformation").DataFields.Count().ShouldEqual(7);
        }
    }
}