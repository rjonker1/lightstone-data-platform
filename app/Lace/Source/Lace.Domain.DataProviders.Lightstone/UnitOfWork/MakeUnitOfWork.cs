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
    public class MakeUnitOfWork : IGetMakes
    {
        private readonly ILog _log;
        public IEnumerable<Make> Makes { get; private set; }
        private readonly IReadOnlyRepository<Make> _repository;

        public MakeUnitOfWork(IReadOnlyRepository<Make> repository)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
        }

        public void GetMakes(IHaveCarInformation request)
        {
            try
            {
                Makes = _repository.GetAll(SelectStatements.GetAllTheMakes);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error getting Make data because of {0}", ex.Message);
            }
        }
    }
}
