using System;
using System.Collections.Generic;

namespace Toolbox.LightstoneAuto.Database.Infrastructure.Dto
{
    public interface IReadModelFacade
    {
        IEnumerable<DataSetDto> GetDataSets();
        DataSetDetailsDto GetDataSet(Guid id);
    }
}
