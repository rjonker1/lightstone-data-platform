using System;
using System.Collections.Generic;
using EasyNetQ;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.Infrastructure.EntryPoint.Specification
{
    public class NullSpecificationProvider : IExecuteSpecification
    {
        public Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid> Execute()
        {
            return _chain();
        }

        private readonly Func<Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid>>
            _chain = () => (request, bus, response, requestId) => new NullDataProvider().CallSource(response);
    }

    public sealed class NullDataProvider : IExecuteTheDataProviderSource
    {
        public void CallSource(ICollection<IPointToLaceProvider> response)
        {
           
        }
    }
}