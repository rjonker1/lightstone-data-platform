using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Request;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository;

namespace Lace.Source.Lightstone.DataObjects
{
    public class MuncipalityData : IGetMuncipalities
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        public IEnumerable<Municipality> Municipalities { get; private set; }
        private readonly IReadOnlyRepository<Municipality> _repository;

        public MuncipalityData(IReadOnlyRepository<Municipality> repository)
        {
            _repository = repository;
        }

        public void GetMunicipalities(IProvideCarInformationForRequest request)
        {
            try
            {
                Municipalities = _repository.GetAll();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error getting Metric data because of {0}", ex.Message);
            }
        }


    }
}
