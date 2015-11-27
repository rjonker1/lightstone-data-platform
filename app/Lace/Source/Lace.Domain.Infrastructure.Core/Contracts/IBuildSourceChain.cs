using System;
using System.Collections.Generic;
using EasyNetQ;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Domain.Infrastructure.Core.Contracts
{
    public interface IBuildSourceChain
    {
        Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid> Build(ChainType chainType);
    }

    public enum ChainType
    {
        All = 1,
        CarId = 2, 
        Undefined = 99
    }
}
