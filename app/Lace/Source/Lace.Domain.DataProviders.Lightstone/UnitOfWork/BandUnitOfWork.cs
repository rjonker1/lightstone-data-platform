using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Domain.DataProviders.Lightstone.UnitOfWork
{
    public class BandUnitOfWork : IGetBands
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        public IEnumerable<Band> Bands { get; private set; }
        private readonly IReadOnlyRepository<Band> _repository;

        public BandUnitOfWork(IReadOnlyRepository<Band> repository)
        {
            _repository = repository;
        }

        public void GetBands(IProvideCarInformationForRequest request)
        {
            try
            {
                Bands = _repository.GetAll();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error getting Band data because of {0}", ex.Message);
            }
        }
    }
}
