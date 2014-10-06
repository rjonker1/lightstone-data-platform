using System;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Lightstone.Core;
using Lace.Domain.DataProviders.Lightstone.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Core.Models;

namespace Lace.Domain.DataProviders.Lightstone.UnitOfWork
{
    public class CarInfoData : IGetCarInfo
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        public IEnumerable<CarInfo> Cars { get; private set; }
        private readonly IReadOnlyRepository<CarInfo> _repository;
        private readonly IReadOnlyRepository<CarInfo> _vin12Repository;

        public CarInfoData(IReadOnlyRepository<CarInfo> repository, IReadOnlyRepository<CarInfo> vin12Repository)
        {
            _repository = repository;
            _vin12Repository = vin12Repository;
        }

        public void GetCarInfo(IProvideCarInformationForRequest request)
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
                Log.ErrorFormat("Error getting Car Info data because of {0}", ex.Message);
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
