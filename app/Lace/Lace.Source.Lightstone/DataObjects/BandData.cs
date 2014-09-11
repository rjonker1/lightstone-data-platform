using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Request;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository;

namespace Lace.Source.Lightstone.DataObjects
{
    public class BandData : IGetBands
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        public IEnumerable<Band> Bands { get; private set; }
        private readonly IReadOnlyRepository<Band> _repository;

        public BandData(IReadOnlyRepository<Band> repository)
        {
            _repository = repository;
        }

        public void GetBands(ILaceRequestCarInformation request)
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
