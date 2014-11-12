﻿using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Castle.Windsor;
using DataPlatform.Shared.Entities;
using PackageBuilder.Api.Installers;
using PackageBuilder.Domain.Dtos;
using PackageBuilder.TestHelper.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Api.Tests.AutoMappers.Dtos
{
    public class when_mapping_data_provider_dto : Specification
    {
        private DataProviderDto _dto;

        public override void Observe()
        {
            var container = new WindsorContainer();
            container.Install(new AutoMapperInstaller());

            _dto = Mapper.Map<IDataProvider, DataProviderDto>(WriteDataProviderMother.Ivid);
        }

        [Observation]
        public void should_map_all_fields()
        {
            

        }
    }
}