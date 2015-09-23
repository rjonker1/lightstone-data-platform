using System;
using System.Linq;
using Common.Logging;
using DataProviders.Lightstone.MMCode.Core.Contracts;
using Lace.Toolbox.Database.Models;
using Lace.Toolbox.Database.Repositories;

namespace DataProviders.MMCode.UnitOfWork
{
    public class MmCodeUnitOfWork : IGetMmCode
    {
        public MmCode MmCode { get; private set; }

        private readonly ILog _log;
        private readonly IReadOnlyRepository _repository;

        public MmCodeUnitOfWork(IReadOnlyRepository repository)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
        }

        public void GetCarMmCode(int carId)
        {
            try
            {
                MmCode = _repository.Get<MmCode>(MmCode.SelectWithCarId, new { carId }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error getting Car Specification data because of {0}", ex, ex.Message);
            }
        }
    }
}