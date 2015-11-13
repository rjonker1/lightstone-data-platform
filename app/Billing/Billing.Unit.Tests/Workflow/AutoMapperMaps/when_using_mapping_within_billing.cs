using System;
using AutoMapper;
using Billing.TestHelper.BaseTests;
using Workflow.Billing.Helpers.AutoMapper.Maps;
using Xunit.Extensions;

namespace Billing.Api.Tests.Workflow.AutoMapperMaps
{
    public class when_using_mapping_within_billing : BaseTestHelper
    {
        public override void Observe()
        {
            
        }

        [Observation]
        public void should_map_client()
        {
            Mapper.Initialize(m => m.AddProfile<ClientMap>());
            Mapper.AssertConfigurationIsValid();
        }

        [Observation]
        public void should_map_contract()
        {
            Mapper.Initialize(m => m.AddProfile<ContractMap>());
            Mapper.AssertConfigurationIsValid();
        }

        [Observation]
        public void should_map_customer()
        {
            Mapper.Initialize(m => m.AddProfile<CustomerMap>());
            Mapper.AssertConfigurationIsValid();
        }

        [Observation]
        public void should_map_finalBilling()
        {
            Mapper.Initialize(m => m.AddProfile<FinalBillingMap>());
            Mapper.AssertConfigurationIsValid();
        }

        [Observation]
        public void should_map_finalBilling_to_userDto()
        {
            Mapper.Initialize(m => m.AddProfile<FinalBillingUserDtoMap>());
            Mapper.AssertConfigurationIsValid();
        }

        [Observation]
        public void should_map_package()
        {
            Mapper.Initialize(m => m.AddProfile<PackageMap>());
            Mapper.AssertConfigurationIsValid();
        }

        [Observation]
        public void should_map_packageMeta()
        {
            Mapper.Initialize(m => m.AddProfile<PackageMetaMaps>());
            Mapper.AssertConfigurationIsValid();
        }

        [Observation]
        public void should_map_preBilling()
        {
            Mapper.Initialize(m => m.AddProfile<PreBillingMap>());
            Mapper.AssertConfigurationIsValid();
        }

        [Observation]
        public void should_map_preBilling_to_userDto()
        {
            Mapper.Initialize(m => m.AddProfile<PreBillingUserDtoMap>());
            Mapper.AssertConfigurationIsValid();
        }

        [Observation]
        public void should_map_stageBilling()
        {
            Mapper.Initialize(m => m.AddProfile<StageBillingMap>());
            Mapper.AssertConfigurationIsValid();
        }

        [Observation]
        public void should_map_stageBilling_to_userDto()
        {
            Mapper.Initialize(m => m.AddProfile<StageBillingUserDtoMap>());
            Mapper.AssertConfigurationIsValid();
        }
    }
}