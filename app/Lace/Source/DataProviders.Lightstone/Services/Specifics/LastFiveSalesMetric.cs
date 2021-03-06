﻿using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Entities;
using Lace.Toolbox.Database.Dtos;
using Lace.Toolbox.Database.Models;

namespace Lace.Domain.DataProviders.Lightstone.Services.Specifics
{
    public class LastFiveSalesMetric : IRetrieveATypeOfMetric<SaleModel>
    {
        public List<SaleModel> MetricResult { get; private set; }
        public IEnumerable<StatisticDto> Statistics { get; private set; }

        private readonly IEnumerable<Sale> _sales;
        private readonly IEnumerable<Municipality> _municipalities;

        public LastFiveSalesMetric(IEnumerable<Sale> sales, IEnumerable<Municipality> municipalities)
        {
            _sales = sales;
            _municipalities = municipalities;
            MetricResult = new List<SaleModel>();
        }

        public IRetrieveATypeOfMetric<SaleModel> Get()
        {
            var result = _sales
                .OrderByDescending(o => o.SaleDateTime)
                .Take(5)
                .Select(
                    s =>
                        new SaleModel(s.SaleDateTime.ToShortDateString(), GetMuncipalityName(s.Municipality_ID),
                            s.SalePrice.ToString("C"))).ToList();

            MetricResult.AddRange(result);

            return this;
        }

        private string GetMuncipalityName(int? municipalityId)
        {
            if (!_municipalities.Any()) return string.Empty;

            var municipality = _municipalities.FirstOrDefault(w => w.Municipality_ID == municipalityId);
            return municipality != null ? municipality.MunicipalityName : string.Empty;
        }
    }
}
