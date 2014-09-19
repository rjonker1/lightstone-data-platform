using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Request;
using Lace.Source.Lightstone.Models;
using Lace.Source.Lightstone.Repository;

namespace Lace.Source.Lightstone.DataObjects
{
    public class MakeData : IGetMakes
    {
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();
        public IEnumerable<Make> Makes { get; private set; }
        private readonly IReadOnlyRepository<Make> _repository;

        public MakeData(IReadOnlyRepository<Make> repository)
        {
            _repository = repository;
        }

        public void GetMakes(IProvideCarInformationForRequest request)
        {
            try
            {
                Makes = _repository.GetAll();
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error getting Make data because of {0}", ex.Message);
            }
        }
    }
}
