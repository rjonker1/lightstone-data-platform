using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.CrossCutting.DataProvider.Car.Core.Models;
using Lace.CrossCutting.DataProvider.Car.Repositories;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.CrossCutting.DataProvider.Car.UnitOfWork
{
    public class CarInfoUnitOfWork : IGetCarInfo
    {
        private readonly ILog _log;
        public IEnumerable<CarInfo> Cars { get; private set; }
        private readonly IReadOnlyCarRepository<CarInfo> _repository;
        private readonly IReadOnlyCarRepository<CarInfo> _vin12Repository;

        public CarInfoUnitOfWork(IReadOnlyCarRepository<CarInfo> repository, IReadOnlyCarRepository<CarInfo> vin12Repository)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
            _vin12Repository = vin12Repository;
        }

        public void GetCarInfo(IHaveCarInformation request)
        {
            try
            {
                if (!string.IsNullOrEmpty(request.Vin))
                {
                    GetCarInfoUsingVin(request.Vin);
                    return;
                }

                GetCarInfoUsingCarId(request.CarId, request.Year);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error getting Car Information because of {0}", ex.Message);
            }
        }

        private void GetCarInfoUsingVin(string vin)
        {
            Cars = _repository.FindByVin(vin);

            if (Cars == null || !Cars.Any())
                Cars = _vin12Repository.FindByVin(vin);
        }

        private void GetCarInfoUsingCarId(int? carId, int? year)
        {
            if (!carId.HasValue || !year.HasValue)
            {
                Cars = new List<CarInfo>();
                return;
            }

            Cars = _repository.FindByCarIdAndYear(carId, (int) year);
        }
    }
}
