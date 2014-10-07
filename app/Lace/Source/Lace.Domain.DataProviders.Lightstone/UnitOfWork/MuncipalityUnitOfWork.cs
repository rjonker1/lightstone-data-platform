using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Domain.DataProviders.Lightstone.UnitOfWork
{
    public class MuncipalityUnitOfWork : IGetMuncipalities
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        public IEnumerable<Municipality> Municipalities { get; private set; }
        private readonly IReadOnlyRepository<Municipality> _repository;

        public MuncipalityUnitOfWork(IReadOnlyRepository<Municipality> repository)
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
