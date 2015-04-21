﻿using System.Collections.Generic;
using PackageBuilder.Domain.Entities.Enums.DataProviders;

namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IAmDataProvider
    {
        DataProviderName Name { get; }
        IEnumerable<IAmRequestField> RequestFields { get; }
        decimal CostPrice { get; }
        decimal RecommendedPrice { get; }
    }
}
