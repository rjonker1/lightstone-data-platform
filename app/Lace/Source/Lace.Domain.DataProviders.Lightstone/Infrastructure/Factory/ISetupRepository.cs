﻿using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Shared.DataProvider.Models;

namespace Lace.Domain.DataProviders.Lightstone.Infrastructure.Factory
{
    public interface ISetupRepository
    {
        IReadOnlyRepository<Band> BandRepository();
        IReadOnlyRepository<Make> MakeRepository();
        IReadOnlyRepository<Metric> MetricRepository();
        IReadOnlyRepository<Municipality> MuncipalityRepository();
        IReadOnlyRepository<Sale> SaleRepository();
        IReadOnlyRepository<Statistic> StatisticRepository();
        void Dispose();
    }
}