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
    public class when_mapping_ivid_title_holder_response : Specification
    {
        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Install(new AutoMapperInstaller());

            var test = Mapper.Map<IProvideDataFromIvidTitleHolder, IEnumerable<IDataField>>(IvidTitleHolderResponseMother.Response);
        }

        [Observation]
        public void configuration_should_be_valid()
        {

        }
    }
}