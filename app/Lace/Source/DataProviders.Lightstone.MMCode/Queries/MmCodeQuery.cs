using System;
using System.Linq;
using Common.Logging;
using DataProviders.MMCode.Core.Contracts;
using Lace.Toolbox.Database.Models;
using Lace.Toolbox.Database.Repositories;

namespace DataProviders.MMCode.Queries
{
    public class MmCodeQuery : IGetMmCode
    {
        private static readonly ILog Log = LogManager.GetLogger<MmCodeQuery>();
        private readonly IReadOnlyRepository _repository;

        public MmCodeQuery(IReadOnlyRepository repository)
        {
            _repository = repository;
        }

        public void GetCarMmCode(int carId)
        {
            try
            {
                MmCode = _repository.Get<MmCode>(MmCode.SelectWithCarId, new {carId}).FirstOrDefault();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error getting MM Code data because of {0}", ex, ex.Message);
                throw;
            }
        }

        public MmCode MmCode { get; private set; }
    }
}