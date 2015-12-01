using System;
using System.Collections.Generic;
using Toolbox.LightstoneAuto.Database.Infrastructure.Dto;

namespace Toolbox.LightstoneAuto.Database.Infrastructure.Read
{
    public class DataSetReadModel : IReadModelFacade
    {
        public IEnumerable<DataSetDto> GetDataSets()
        {
            throw new NotImplementedException();
        }

        public DataSetDetailsDto GetDataSet(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
