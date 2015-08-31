﻿using System.Collections.Generic;
using Lace.Shared.DataProvider.Models;

namespace Lace.Domain.DataProviders.Lightstone.Services
{
    public interface IRetrieveATypeOfMetric<T>
    {
        List<T> MetricResult { get; }
        IEnumerable<Statistic> Statistics { get; }
        IRetrieveATypeOfMetric<T> Get();
    }
}