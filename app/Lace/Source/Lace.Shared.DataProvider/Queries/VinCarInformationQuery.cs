using System;
using System.Linq;
using Common.Logging;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Dtos;
using Lace.Toolbox.Database.Repositories;

namespace Lace.Toolbox.Database.Queries
{
    public class VinCarInformationQuery : AbstractCarInformationQuery , IGetCarInformation
    {
        private static readonly ILog Log = LogManager.GetLogger<VinCarInformationQuery>();
        private readonly IReadOnlyRepository _repository;

        public VinCarInformationQuery(IGetCarInformation next, IReadOnlyRepository repository) : base(next)
        {
            _repository = repository;
        }

        public void GetCarInformation(IHaveCarInformation request)
        {
            try
            {
                if (string.IsNullOrEmpty(request.Vin))
                {
                    Cars = CallNext(request);
                    return ;
                }

                if (CacheAvailable) Cars = _repository.GetAll<CarInformationDto>(car => car.Vin == request.Vin).ToList();

                if (Cars == null || !Cars.Any())
                    Cars = _repository.Get<CarInformationDto>(CarInformationDto.SelectWithVin, new { request.Vin }).ToList();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error getting Car Information because of {0}", ex, ex.Message);
            }

            CallNext(request);
        }

        public System.Collections.Generic.List<CarInformationDto> Cars { get; private set; }
    }
}