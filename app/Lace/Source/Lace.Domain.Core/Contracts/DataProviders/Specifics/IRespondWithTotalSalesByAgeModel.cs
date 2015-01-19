﻿using DataPlatform.Shared.Entities;
using Lace.Domain.Core.Contracts.DataProviders.Metric;

namespace Lace.Domain.Core.Contracts.DataProviders.Specifics
{
    public interface IRespondWithTotalSalesByAgeModel : IProvideType
    {
        string Band { get; }
        IPair<string, double>[] Values { get; }
    }
}