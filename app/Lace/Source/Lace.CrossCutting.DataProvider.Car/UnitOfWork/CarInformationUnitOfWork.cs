using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.CrossCutting.DataProvider.Car.Core.Models;
using Lace.CrossCutting.DataProvider.Car.Infrastructure.SqlStatements;
using Lace.CrossCutting.DataProvider.Car.Repositories;
using Lace.Domain.Core.Requests.Contracts;
using ServiceStack.Common.Extensions;

namespace Lace.CrossCutting.DataProvider.Car.UnitOfWork
{
    public class CarInformationUnitOfWork : IGetCarInformation
    {
        private readonly ILog _log;
        public IEnumerable<CarInformation> Cars { get; private set; }
        private readonly IReadOnlyCarRepository<CarInformation> _repository;
        private readonly IReadOnlyCarRepository<CarInformation> _vin12Repository;

        public CarInformationUnitOfWork(IReadOnlyCarRepository<CarInformation> repository, IReadOnlyCarRepository<CarInformation> vin12Repository)
        {
            _log = LogManager.GetLogger(GetType());
            _repository = repository;
            _vin12Repository = vin12Repository;
        }

        public void GetCarInformation(IHaveCarInformation request)
        {
            try
            {
                GetCarInformationWithVin(request);
                GetCarWithCarIdAndYear(request);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error getting Car Information because of {0}", ex.Message);
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

            Cars = _repository.Get(SelectStatements.GetCarInformationWithVin, new {request.Vin});

            if (!ItMightBeAVin12())
                return;

            Cars = _vin12Repository.Get(SelectStatements.GetCarInformationWithVin12, new {request.Vin}).ToList();
            if (Cars.Any())
            {
                Cars.ForEach(f => f.IsAVin12Car());
            }
        }

        private static bool HasValidRequestInformation(IHaveCarInformation request)
        {
            return request.CarId > 0 && request.Year > 0;
        }

        private void GetCarWithCarIdAndYear(IHaveCarInformation request)
        {
            if (NoNeedToContinue())
                return;

            if (!HasValidRequestInformation(request))
            {
                Cars = new List<CarInformation>();
                return;
            }

            Cars = _repository.GetAll(SelectStatements.GetCarInformation)
                .Where(w => w.CarId == request.CarId && w.Year == request.Year);
        }
    }
}
