using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Acceptance.Tests.Helper;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Core.Shared;
using Lace.Domain.DataProviders.Ivid.Infrastructure;
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
        private IvidDataRetriever _retriever;
        private readonly ILog _log = LogManager.GetLogger<when_requesting_ivid_data_from_the_cache>();
        private ILogCommandTypes _logCommand;

        private HpiStandardQueryRequest _ividRequest;

        public when_requesting_ivid_data_from_the_cache()
        {
            _request = new[] { new LicensePlateNumberIvidOnlyRequest() };
            _dataProvider = _request.First().Package.DataProviders.Single(w => w.Name == DataProviderName.IVIDVerify_E_WS);
            _logCommand = LogCommandTypes.ForDataProvider(_command, DataProviderCommandSource.IVIDVerify_E_WS, _dataProvider);
        }

        public override void Observe()
        {
            TestCacheRepository.ClearAll();
            _ividRequest = HandleRequest.GetHpiStandardQueryRequest(_dataProvider.GetRequest<IAmIvidStandardRequest>());
            _retriever = IvidDataRetriever.Start(_logCommand, _log).ThenWithApi(_ividRequest, _dataProvider, out _response);
            var transformer = new TransformIvidResponse(_response);
            transformer.Transform();
        }

        //[Observation]
        //public void then_request_for_license_number_should_exist_in_cache()
        //{
        //    _request  = new[] { new LicensePlateNumberIvidOnlyRequest() };
        //    _ividRequest = HandleRequest.GetHpiStandardQueryRequest(_dataProvider.GetRequest<IAmIvidStandardRequest>());
        //    var retriever = IvidDataRetriever.Start(_logCommand, _log)
        //        .CheckInCache(_ividRequest);

        //    Task.Delay(5000);

        //    retriever.NoNeedToCallApi.ShouldBeTrue();
        //    retriever.CacheResponse.ShouldNotBeNull();
        //    retriever.CacheResponse.Vin.ShouldEqual("3C4PDCKG7DT526617");
        //}

        //[Observation]
        //public void then_request_for_vin_number_should_exist_in_cache()
        //{
        //    _request = new[] { new VinNumberIvidOnlyRequest() };
        //    _ividRequest = HandleRequest.GetHpiStandardQueryRequest(_dataProvider.GetRequest<IAmIvidStandardRequest>());
        //    var retriever = IvidDataRetriever.Start(_logCommand, _log)
        //        .CheckInCache(_ividRequest);
        //    Task.Delay(5000);

        //    retriever.NoNeedToCallApi.ShouldBeTrue();
        //    retriever.CacheResponse.ShouldNotBeNull();
        //    retriever.CacheResponse.License.ShouldEqual("CN62KZGP");
        //}

        //[Observation]
        //public void then_request_for_register_no_should_exist_in_cache()
        //{
        //    _request = new[] { new RegisterNumberIvidOnlyRequest() };
        //    _ividRequest = HandleRequest.GetHpiStandardQueryRequest(_dataProvider.GetRequest<IAmIvidStandardRequest>());
        //    var retriever = IvidDataRetriever.Start(_logCommand, _log)
        //        .CheckInCache(_ividRequest);
        //    Task.Delay(5000);

        //    retriever.NoNeedToCallApi.ShouldBeTrue();
        //    retriever.CacheResponse.ShouldNotBeNull();
        //    retriever.CacheResponse.License.ShouldEqual("CN62KZGP");
        //}
    }
}
