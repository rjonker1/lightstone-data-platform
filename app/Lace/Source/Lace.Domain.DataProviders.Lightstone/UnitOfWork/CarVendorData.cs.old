using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Request;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository;

namespace Lace.Source.Lightstone.DataObjects
{
    public class CarVendorData : IGetCarVendor
    {
        private readonly ILog Log = LogManager.GetCurrentClassLogger();
        public IEnumerable<CarVendor> CarVendors { get; private set; }
        private readonly IReadOnlyRepository<CarVendor> _repository;

        public CarVendorData(IReadOnlyRepository<CarVendor> repository)
        {
            _repository = repository;
        }

        public void GetCarVendors(ILaceRequestCarInformation request)
        {
            try
            {
                CarVendors = _repository.GetAll();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error getting Car Vendor data because of {0}", ex.Message);
            }
        }
    }
}
