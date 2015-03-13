using System;
using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using NServiceBus;

namespace Lace.Domain.Infrastructure.Core.Contracts
{
    public interface IBuildSourceChain
    {
        void Build();
        Action<ILaceRequest, IBus, ICollection<IPointToLaceProvider>, Guid> SourceChain { get; }
    }
}
