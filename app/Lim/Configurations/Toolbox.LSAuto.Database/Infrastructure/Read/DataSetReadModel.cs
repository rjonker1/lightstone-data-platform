using System;
using System.Collections.Generic;
using Lim.Dtos;
using Toolbox.LightstoneAuto.Domain;

namespace Toolbox.LightstoneAuto.Infrastructure.Read
{
    public class DataSetReadModel : IReadModelFacade
    {
        public IEnumerable<DataSetDto> GetDataSets()
        {
            throw new NotImplementedException();
        }

        //public DataSetDetailsDto GetDataSet(Guid id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
