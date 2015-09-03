using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Toolbox.Database.Models;
using Lace.Toolbox.Database.Repositories;

namespace Lace.CrossCutting.DataProvider.Car.UnitOfWork
{
    public class CarInformationWorker : IGetCarInformation
    {
        private readonly ILog _log;
        public IEnumerable<CarInformation> Cars { get; private set; }
        private readonly IReadOnlyRepository _repository;

        public CarInformationWorker(IReadOnlyRepository repository)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
        }

        public void GetCarInformation(IHaveCarInformation request)
        {
            try
            {
                GetCarInformationWithVin(request);
                GetWithCarId(request);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error getting Car Information because of {0}", ex, ex.Message);
            }
        }

        private static bool CannotGetWithVin(string vin)
        {
            return string.IsNullOrEmpty(vin);
        }

        private bool ItMightBeAVin12()
        {
            return (Cars == null || !Cars.Any());
        }

        private bool NoNeedToContinue()
        {
            return Cars != null && Cars.Any() && Cars.FirstOrDefault(f => f.CarId > 0 && f.Year > 0) != null;
        }

        private void GetCarInformationWithVin(IHaveCarInformation request)
        {
            if (CannotGetWithVin(request.Vin))
                return;

            Cars = _repository.GetAll<CarInformation>(car => car.Vin == request.Vin);

            if (!Cars.Any())
                Cars = _repository.Get<CarInformation>(CarInformation.SelectWithVin, new {request.Vin});
        }


        private static bool HasValidCarIdInformation(IHaveCarInformation request)
        {
            return request.CarId > 0;
        }

        private void GetWithCarId(IHaveCarInformation request)
        {
            if (NoNeedToContinue())
                return;

            if (!HasValidCarIdInformation(request))
            {
                Cars = new List<CarInformation>();
                return;
            }

            Cars = _repository.GetAll<CarInformation>(car => car.CarId == request.CarId);

            if (!Cars.Any())
                Cars = _repository.Get<CarInformation>(CarInformation.SelectWithCarId, new {request.CarId});
        }
    }
}