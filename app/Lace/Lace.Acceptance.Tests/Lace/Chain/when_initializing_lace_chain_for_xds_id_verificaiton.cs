using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DataPlatform.Shared.Enums;
using EasyNetQ;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Extensions;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint;
using Lace.Domain.Infrastructure.EntryPoint.Builder.Factory;
using Lace.Test.Helper.Builders.Buses;
using Lace.Test.Helper.Builders.Requests;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Lace.Chain
{
    public class when_initializing_lace_chain_for_xds_id_verificaiton : Specification
    {
        private IBootstrap _initialize;
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly IAdvancedBus _command;
        private readonly IBuildSourceChain _buildSourceChain;


        public when_initializing_lace_chain_for_xds_id_verificaiton()
        {
            _command = BusFactory.WorkflowBus();
            _request = new XdsRequestBuilder().ForIdVerificaitonWithIdNumber();
            _buildSourceChain = new SpecificationFactory();
        }

        public override void Observe()
        {
            _initialize = new Initialize(new Collection<IPointToLaceProvider>(), _request, _command, _buildSourceChain);
            _initialize.Execute(ChainType.All);
          
        }

        [Observation]
        public void then_verifcation_result_should_be_valid()
        {
            _initialize.DataProviderResponses.ShouldNotBeNull();
            _initialize.DataProviderResponses.Count.ShouldEqual(14);
            _initialize.DataProviderResponses.Count(c => c.Handled).ShouldEqual(1);

            _initialize.DataProviderResponses.HasAllRecords().ShouldBeTrue();
            _initialize.DataProviderResponses.State().ShouldEqual(DataProviderResponseState.Successful);

            _initialize.DataProviderResponses.OfType<IProvideDataFromXdsIdentityVerification>().First().ShouldNotBeNull();
            _initialize.DataProviderResponses.OfType<IProvideDataFromXdsIdentityVerification>().First().Handled.ShouldBeTrue();
            _initialize.DataProviderResponses.OfType<IProvideDataFromXdsIdentityVerification>().First().IdentityVerifications.Count().ShouldEqual(1);

            _initialize.DataProviderResponses.OfType<IProvideDataFromXdsIdentityVerification>().First().IdentityVerifications.First().FirstName.ShouldEqual("RUDI");
            _initialize.DataProviderResponses.OfType<IProvideDataFromXdsIdentityVerification>().First().IdentityVerifications.First().HomeAffairsId.ShouldEqual("61180391");

            _initialize.DataProviderResponses.OfType<IProvideDataFromVin12>().Any().ShouldBeFalse();
        }
    }
}
