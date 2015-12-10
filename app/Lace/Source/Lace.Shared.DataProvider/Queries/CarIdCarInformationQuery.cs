using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Dtos;
using Lace.Toolbox.Database.Repositories;

namespace Lace.Toolbox.Database.Queries
{
    public class CarIdCarInformationQuery : AbstractCarInformationQuery, IGetCarInformation
    {
        private static readonly ILog Log = LogManager.GetLogger<CarIdCarInformationQuery>();
        private readonly IReadOnlyRepository _repository;

        public CarIdCarInformationQuery(IGetCarInformation next, IReadOnlyRepository repository) : base(next)
        {
            _repository = repository;
        }

        public void GetCarInformation(IHaveCarInformation request)
        {
            try
            {
                if (request.CarId <= 0)
                {
                    Cars = CallNext(request);
                    return;
                }

                if (CacheAvailable) Cars = _repository.GetAll<CarInformationDto>(car => car.CarId == request.CarId).ToList();

                if (Cars == null || !Cars.Any())
                    Cars = _repository.Get<CarInformationDto>(CarInformationDto.SelectWithCarId, new {request.CarId}).ToList();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error getting Car Information because of {0}", ex, ex.Message);
            }

            CallNext(request);
        }

        public List<CarInformationDto> Cars { get; private set; }
    }
}