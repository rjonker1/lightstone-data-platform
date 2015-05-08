using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Shared.DataProvider.Models;
using Lace.Shared.DataProvider.Repositories;
using ServiceStack.Common.Extensions;

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
                GetCarWithCarIdAndYear(request);
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

            Cars = _repository.GetAll<CarInformation>(CarInformation.SelectAllWithValidCarIdAndYear)
                .Where(w => w.Vin == request.Vin);

            if (!Cars.Any())
                Cars = _repository.Get<CarInformation>(CarInformation.SelectWithVin, new {request.Vin});

            if (!ItMightBeAVin12())
                return;

            Cars = _repository.Get<CarInformation>(CarInformation.SelectWithVin12, new { request.Vin }).ToList();
            if (Cars.Any())
            {
                Cars.ForEach(f => f.IsAVin12Car());
            }
        }

        private static bool HasValidCarIdAndYearInformation(IHaveCarInformation request)
        {
            return request.CarId > 0 && request.Year > 0;
        }

        private static bool HasValidCarIdInformation(IHaveCarInformation request)
        {
            return request.CarId > 0;
        }

        private void GetCarWithCarIdAndYear(IHaveCarInformation request)
        {
            if (NoNeedToContinue())
                return;

            if (!HasValidCarIdAndYearInformation(request))
            {
                Cars = new List<CarInformation>();
                return;
            }

            Cars = _repository.GetAll<CarInformation>(CarInformation.SelectAllWithValidCarIdAndYear)
                .Where(w => w.CarId == request.CarId && w.Year == request.Year);
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

            Cars = _repository.GetAll<CarInformation>(CarInformation.SelectAllWithCarId)
                .Where(w => w.CarId == request.CarId);

            if (!Cars.Any())
                Cars = _repository.Get<CarInformation>(CarInformation.SelectWithCarId, new {request.CarId});
        }
    }
}