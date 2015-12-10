using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Dtos;
using Lace.Toolbox.Database.Models;
using Lace.Toolbox.Database.Repositories;
using Lace.Toolbox.Database.Views;

namespace Lace.Domain.DataProviders.Lightstone.Queries
{
    public class ValuationViewQuery : IGetValuationView
    {
        private static readonly ILog Log = LogManager.GetLogger<ValuationViewQuery>();
        private readonly IReadOnlyRepository _repository;

        public ValuationViewQuery(IReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public void GetValuation(IHaveCarInformation request)
        {
            try
            {
                var valuation = _repository.MultipleItems<Sale, StatisticDto>(ValuationView.SelectValuationQueries, new { request.CarId, request.Year, request.MakeId }).ToList();
                Sales = (List<Sale>)valuation[0] ?? new List<Sale>();
                Statistics = (List<StatisticDto>)valuation[1] ?? new List<StatisticDto>();

            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error getting Valuation data because of {0}", ex, ex.Message);
                throw;
            }
        }

        public List<Sale> Sales { get; private set; }
        public List<StatisticDto> Statistics { get; private set; }
    }
}
