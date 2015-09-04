using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Models;
using Lace.Toolbox.Database.Repositories;

namespace Lace.Domain.DataProviders.Lightstone.UnitOfWork
{
    public class MuncipalityUnitOfWork : IGetMuncipalities
    {
        private readonly ILog _log;
        public IEnumerable<Municipality> Municipalities { get; private set; }
        private readonly IReadOnlyRepository _repository;

        public MuncipalityUnitOfWork(IReadOnlyRepository repository)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
        }

        public void GetMunicipalities(IHaveCarInformation request)
        {
            try
            {
                Municipalities = _repository.GetAll<Municipality>(null);
                if (!Municipalities.Any())
                    Municipalities = _repository.Get<Municipality>(Municipality.SelectAll, new { });
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error getting Metric data because of {0}", ex, ex.Message);
                throw;
            }
        }
    }
}
