using System;
using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders.Consumer;
using Lace.Domain.Core.Contracts.Requests;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideDataFromPCubedEzScore : IPointToLaceProvider
    {
        IAmPCubedEzScoreRequest Request { get; }
        IEnumerable<IRespondWithEzScore> EzScoreRecords { get; }
    }
}
