using System;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Shared.Monitoring.Messages.Shared;

namespace Lace.Domain.Infrastructure.Core.Contracts
{
    public interface IBuildSourceChain
    {
        void Build();
        Action<ILaceRequest, ISendMonitoringMessages, IProvideResponseFromLaceDataProviders> SourceChain { get; }
    }
}
