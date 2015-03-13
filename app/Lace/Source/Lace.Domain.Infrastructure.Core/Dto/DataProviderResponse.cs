using System;
using System.Collections.Generic;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.Infrastructure.Core.Dto
{
    public class DataProviderResponse : IProvideResponseFromDataProviders
    {
        public IEnumerable<IPointToLaceProvider> Responses { get; set; }
    }
}
