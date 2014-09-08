using System.Collections.Generic;
using System.Linq;
using Lace.Models.Lightstone;
using Lace.Models.Lightstone.Dto;
using Lace.Request;
using Lace.Source.Lightstone.DataObjects;
using Lace.Source.Lightstone.Repository.Factory;

namespace Lace.Source.Lightstone.Cars
{
    public class RetrieveCarVendorDetail : IRetrieveCarDetailFromCarVendorInformation
    {
        private IGetCarVendor _getCarVendorInfo;
        private readonly ILaceRequestCarInformation _request;
        private readonly ISetupRepositoryForModels _repositories;

        public bool IsSatisfied { get; private set; }
        public IEnumerable<IRespondWithCarModel> CarModels { get; private set; }

        public RetrieveCarVendorDetail(ILaceRequestCarInformation request,  IEnumerable<IRespondWithCarModel> carModels,
            ISetupRepositoryForModels repositories)
        {
            _request = request;
            _repositories = repositories;
            CarModels = carModels;
        }

        public IRetrieveCarDetailFromCarVendorInformation SetupDataSources()
        {
            _getCarVendorInfo = new CarVendorData(_repositories.CarVendorRepository());
            return this;
        }

        public IRetrieveCarDetailFromCarVendorInformation GenerateData()
        {
            _getCarVendorInfo.GetCarVendors(_request);
            return this;
        }

        public IRetrieveCarDetailFromCarVendorInformation BuildCarModels()
        {
            if (_request.CarId == null || _request == null) return this;


            CarModels = _getCarVendorInfo.CarVendors
                .Select(
                    s =>
                        new CarModel(s.CarModelId, s.CarId, s.CarMake, s.CarType, s.CarYearId, s.CarModelName,
                            s.CarFullname, s.ImageUrl));


            IsSatisfied = true;
            return this;
        }
    }
}
