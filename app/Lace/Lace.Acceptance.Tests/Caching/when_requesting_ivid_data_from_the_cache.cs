using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Acceptance.Tests.Helper;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Core.Shared;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Dto;
using Lace.Domain.DataProviders.Ivid.Infrastructure.Management;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;
using Lace.Shared.Extensions;
using Lace.Test.Helper.Mothers.Requests;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Workflow.Lace.Messages.Core;
using Xunit.Extensions;

namespace Lace.Acceptance.Tests.Caching
{
    public class when_requesting_ivid_data_from_the_cache : Specification
    {
        private ICollection<IPointToLaceRequest> _request;
        private IAmDataProvider _dataProvider;
        private readonly ISendCommandToBus _command;
        private HpiStandardQueryResponse _response;
        private VechicleRetriever _retriever;
        private readonly ILog _log = LogManager.GetLogger<when_requesting_ivid_data_from_the_cache>();
        private ILogCommandTypes _logCommand;

        private HpiStandardQueryRequest _ividRequest;

        public when_requesting_ivid_data_from_the_cache()
        {
            _request = new[] { new LicensePlateNumberIvidOnlyRequest() };
            _dataProvider = _request.First().Package.DataProviders.Single(w => w.Name == DataProviderName.Ivid);
            _logCommand = LogCommandTypes.ForDataProvider(_command, DataProviderCommandSource.Ivid, _dataProvider);
        }

        public override void Observe()
        {
            TestCacheRepository.ClearAll();
            _ividRequest = new IvidRequestMessage(_dataProvider.GetRequest<IAmIvidStandardRequest>()).HpiQueryRequest;
            _retriever = VechicleRetriever.Start(_logCommand, _log).ThenWithApi(_ividRequest, _dataProvider, out _response);
            var transformer = new TransformIvidResponse(_response);
            transformer.Transform();
        }

        [Observation]
        public void then_request_for_license_number_should_exist_in_cache()
        {
            _request  = new[] { new LicensePlateNumberIvidOnlyRequest() };
            _ividRequest = new IvidRequestMessage(_dataProvider.GetRequest<IAmIvidStandardRequest>()).HpiQueryRequest;
            var retriever = VechicleRetriever.Start(_logCommand, _log)
                .FirstWithCache(_ividRequest);

            retriever.NoNeedToCallApi.ShouldBeTrue();
            retriever.CacheResponse.ShouldNotBeNull();
            retriever.CacheResponse.Vin.ShouldEqual("3C4PDCKG7DT526617");
        }

        [Observation]
        public void then_request_for_vin_number_should_exist_in_cache()
        {
            _request = new[] { new VinNumberIvidOnlyRequest() };
            _ividRequest = new IvidRequestMessage(_dataProvider.GetRequest<IAmIvidStandardRequest>()).HpiQueryRequest;
            var retriever = VechicleRetriever.Start(_logCommand, _log)
                .FirstWithCache(_ividRequest);

            retriever.NoNeedToCallApi.ShouldBeTrue();
            retriever.CacheResponse.ShouldNotBeNull();
            retriever.CacheResponse.License.ShouldEqual("CN62KZGP");
        }

        [Observation]
        public void then_request_for_register_no_should_exist_in_cache()
        {
            _request = new[] { new RegisterNumberIvidOnlyRequest() };
            _ividRequest = new IvidRequestMessage(_dataProvider.GetRequest<IAmIvidStandardRequest>()).HpiQueryRequest;
            var retriever = VechicleRetriever.Start(_logCommand, _log)
                .FirstWithCache(_ividRequest);

            retriever.NoNeedToCallApi.ShouldBeTrue();
            retriever.CacheResponse.ShouldNotBeNull();
            retriever.CacheResponse.License.ShouldEqual("CN62KZGP");
        }
    }
}
