using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Models;
using Lace.Toolbox.Database.Repositories;

namespace Lace.Domain.DataProviders.Lightstone.Queries
{
    public class BandQuery : IGetBands
    {
        private readonly ILog _log;
        public IEnumerable<Band> Bands { get; private set; }
        private readonly IReadOnlyRepository _repository;

        public BandQuery(IReadOnlyRepository repository)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
        }

        public void GetBands(IHaveCarInformation request)
        {
            try
            {
                Bands = _repository.GetAll<Band>(null);
                if (!Bands.Any())
                    Bands = _repository.Get<Band>(Band.SelectAll, new {});
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error getting Band data because of {0}", ex, ex.Message);
                throw;
            }
        }
    }
}
