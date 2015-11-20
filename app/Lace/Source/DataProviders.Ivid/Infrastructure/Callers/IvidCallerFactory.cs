using System;
using Common.Logging;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure.Callers
{
    public interface ICallFactory
    {
        ICallTheDataProviderSource Create();
    }

    public class IvidCallerFactory : ICallFactory
    {
        private static readonly ILog Log = LogManager.GetLogger<IvidCallerFactory>();
        private readonly HpiStandardQueryRequest _request;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;

        public IvidCallerFactory(IAmDataProvider dataProvider, ILogCommandTypes logCommand)
        {
            _dataProvider = dataProvider;
            _logCommand = logCommand;
            _request = GetRequest(_dataProvider);
        }

        public ICallTheDataProviderSource Create()
        {
            return
                new CallIvidDataProvider(
                    new IvidCacheCaller(new IvidApiCaller(new IvidNullCaller(), _request, _dataProvider, _logCommand), _request, _dataProvider,
                        _logCommand), _logCommand);
            //return
            // new CallIvidDataProvider(
            //     new IvidCacheCaller(new IvidApiAsyncCaller(new IvidNullCaller(), _request, _dataProvider, _logCommand), _request, _dataProvider,
            //         _logCommand), _logCommand);
        }

        private static HpiStandardQueryRequest GetRequest(IAmDataProvider dataProvider)
        {
            try
            {
                return HandleRequest.GetHpiStandardQueryRequest(dataProvider.GetRequest<IAmIvidStandardRequest>());
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An error occurred in the Ivid Caller Factory because of {0}", ex, ex.Message);
            }

            return new HpiStandardQueryRequest();
        }
    }
}