using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Shared.DataProvider.Models;
using Lace.Shared.DataProvider.Repositories;

namespace Lace.Domain.DataProviders.Lightstone.UnitOfWork
{
    public class MakeUnitOfWork : IGetMakes
    {
        private readonly ILog _log;
        public IEnumerable<Make> Makes { get; private set; }
        private readonly IReadOnlyRepository _repository;

        public MakeUnitOfWork(IReadOnlyRepository repository)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
        }

        public void GetMakes(IHaveCarInformation request)
        {
            try
            {
                Makes = _repository.GetAll<Make>(Make.SelectAll);
                if (!Makes.Any())
                    Makes = _repository.Get<Make>(Make.SelectAll, new {});
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error getting Make data because of {0}", ex, ex.Message);
            }
        }
    }
}
