using System;
using AutoMapper;
using DataPlatform.Shared.Repositories;
using Moq;
using Workflow.Billing.Domain.Entities;
using Xunit.Extensions;

namespace Billing.Api.Tests.Consumers.Entity
{
    public class when_executing_bill_run_from_pre_to_stage : Specification
    {
        private readonly Mock<IRepository<PreBilling>> _preBillingRepository;
        private readonly Mock<IRepository<StageBilling>> _stageBillingRepository;

        private Exception thrownException;

        public when_executing_bill_run_from_pre_to_stage()
        {
            _preBillingRepository = new Mock<IRepository<PreBilling>>();
            _stageBillingRepository = new Mock<IRepository<StageBilling>>();
        }

        public override void Observe()
        {
            try
            {
                Mapper.CreateMap<IRepository<PreBilling>, IRepository<StageBilling>>();
                var toStageBilling = Mapper.Map(_preBillingRepository.Object, _stageBillingRepository.Object);
            }
            catch (Exception e)
            {
                thrownException = e;
            }
        }

        [Observation]
        public void should_map_data_to_stage()
        {
            thrownException.ShouldBeNull();
        }
    }
}