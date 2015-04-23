using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core.Models;
using Lace.Domain.DataProviders.Lightstone.Infrastructure.SqlStatements;

namespace Lace.Domain.DataProviders.Lightstone.UnitOfWork
{
    public class MuncipalityUnitOfWork : IGetMuncipalities
    {
        private readonly ILog _log;
        public IEnumerable<Municipality> Municipalities { get; private set; }
        private readonly IReadOnlyRepository<Municipality> _repository;

        public MuncipalityUnitOfWork(IReadOnlyRepository<Municipality> repository)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
        }

        public void GetMunicipalities(IHaveCarInformation request)
        {
            try
            {
                Municipalities = _repository.GetAll(SelectStatements.GetAllTheMuncipalities);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error getting Metric data because of {0}", ex.Message);
            }
        }


    }
}
