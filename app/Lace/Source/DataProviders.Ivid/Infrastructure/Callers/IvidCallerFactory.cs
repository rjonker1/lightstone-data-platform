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
        private readonly HpiStandardQueryRequest _request;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;

        public IvidCallerFactory(IAmDataProvider dataProvider, ILogCommandTypes logCommand)
        {
            _request = HandleRequest.GetHpiStandardQueryRequest(_dataProvider.GetRequest<IAmIvidStandardRequest>());
            _dataProvider = dataProvider;
            _logCommand = logCommand;
        }

        public ICallTheDataProviderSource Create()
        {
            return
                new CallIvidDataProvider(
                    new IvidCacheCaller(new IvidApiCaller(new IvidNullCaller(), _request, _dataProvider, _logCommand), _request, _dataProvider,
                        _logCommand), _logCommand);
        }
    }
}