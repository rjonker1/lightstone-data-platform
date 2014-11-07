using System.Collections.Generic;
using AutoMapper;
using Castle.Windsor;
using DataPlatform.Shared.Entities;
using Lace.Domain.Core.Contracts.DataProviders;
using PackageBuilder.Api.Installers;
using PackageBuilder.TestHelper.Builders.Mothers.DataProviderResponses;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMappers
{
    public class when_mapping_ivid_response : Specification
    {
        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Install(new AutoMapperInstaller());

            var test = Mapper.Map<IProvideDataFromIvid, IEnumerable<IDataField>>(IvidResponseMother.Response);
        }

        [Observation]
        public void configuration_should_be_valid()
        {

        }
    }
}