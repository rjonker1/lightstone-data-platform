using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure.Callers
{
    public class AbstractIvidCaller
    {
        private readonly ICallTheDataProviderSource _next;
        protected AbstractIvidCaller()
        {
           
        }
        protected AbstractIvidCaller(ICallTheDataProviderSource next)
        {
            _next = next;
        }

        protected void CallNext(ICollection<IPointToLaceProvider> response)
        {
            if(_next == null) return;
            _next.CallTheDataProvider(response);
        }
    }
}
