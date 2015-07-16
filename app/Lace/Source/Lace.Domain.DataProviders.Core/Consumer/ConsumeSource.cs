using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.Core.Consumer
{
    public sealed class ConsumeSource : IConsumeDataProviderSource
    {
        private readonly ICallTheDataProviderSource _dataProviderCall;
        private readonly IHandleDataProviderSourceCall _handleDataProviderCall;


        public ConsumeSource(IHandleDataProviderSourceCall handleDataProviderCall,
            ICallTheDataProviderSource dataProviderCall)
        {
            _handleDataProviderCall = handleDataProviderCall;
            _dataProviderCall = dataProviderCall;
        }

        public void ConsumeDataProvider(ICollection<IPointToLaceProvider> response)
        {
            _handleDataProviderCall
                .Request(c =>
                    c.FetchDataFromSource(response, _dataProviderCall));
        }
    }
}
