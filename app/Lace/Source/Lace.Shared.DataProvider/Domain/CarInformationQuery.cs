using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Dtos;
using Lace.Toolbox.Database.Repositories;

namespace Lace.Toolbox.Database.Domain
{
    public class CarInformationQuery : IGetCarInformation
    {
        private static readonly ILog Log = LogManager.GetLogger<CarInformationQuery>();
        public IEnumerable<CarInformationDto> Cars { get; private set; }
        private readonly IReadOnlyRepository _repository;

        public CarInformationQuery(IReadOnlyRepository repository)
        {
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
                Log.ErrorFormat("Error getting Car Information because of {0}", ex, ex.Message);
                throw;
            }
        }

        private static bool CannotGetWithVin(string vin)
        {
            return string.IsNullOrEmpty(vin);
        }
        
        private bool NoNeedToContinue()
        {
            return Cars != null && Cars.Any() && Cars.FirstOrDefault(f => f.CarId > 0 && f.Year > 0) != null;
        }

        private void GetCarInformationWithVin(IHaveCarInformation request)
        {
            if (CannotGetWithVin(request.Vin))
                return;

            Cars = _repository.GetAll<CarInformationDto>(car => car.Vin == request.Vin);

            if (!Cars.Any())
                Cars = _repository.Get<CarInformationDto>(CarInformationDto.SelectWithVin, new {request.Vin});
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
                Cars = new List<CarInformationDto>();
                return;
            }

            Cars = _repository.GetAll<CarInformationDto>(car => car.CarId == request.CarId);

            if (!Cars.Any())
                Cars = _repository.Get<CarInformationDto>(CarInformationDto.SelectWithCarId, new {request.CarId});
        }

    }
}